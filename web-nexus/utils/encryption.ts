import * as crypto from "crypto";

export function encrypt(text: string): string {
    const secretKey: string | undefined = process.env.NEXTAUTH_SECRET;

    if (!secretKey) {
        throw new Error("Secret key not provided");
    }

    const algorithm = "aes-256-cbc";
    const key = crypto.createHash("sha256").update(secretKey).digest("hex").slice(0, 32);
    const iv = crypto.randomBytes(16);

    const cipher = crypto.createCipheriv(algorithm, key, iv);
    let encryptedString = cipher.update(text, "utf-8", "hex");
    encryptedString += cipher.final("hex");

    return iv.toString("hex") + encryptedString;
}

export function decrypt(encryptedString: string): string {
    const secretKey: string | undefined = process.env.NEXTAUTH_SECRET;

    if (!secretKey) {
        throw new Error("Secret key not provided");
    }

    const algorithm = "aes-256-cbc";
    const key = crypto.createHash("sha256").update(secretKey).digest("hex").slice(0, 32);

    const iv = Buffer.from(encryptedString.slice(0, 32), "hex");
    const encryptedText = encryptedString.slice(32);

    const decipher = crypto.createDecipheriv(algorithm, key, iv);
    let decryptedString = decipher.update(encryptedText, "hex", "utf-8");
    decryptedString += decipher.final("utf-8");

    return decryptedString;
}
