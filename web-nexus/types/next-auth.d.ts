import NextAuth, { DefaultSession } from "next-auth"

declare module 'next-auth' {
    interface Session {
        accessToken?: string,
        id_token: string,
        user: {
            
        } & DefaultSession["user"]
    }
}

declare module 'next-auth/jwt' {
    interface JWT {
        id_token?: string
        provider?: string
        accessToken?: string
    }
}
