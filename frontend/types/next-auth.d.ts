import NextAuth, { DefaultSession } from "next-auth"

declare module 'next-auth' {
    interface Session {
        access_token?: string,
        id_token: string,
        roles: Array<string>,
        error?: string,
        groups?: string[],
        user: {

        } & DefaultSession["user"]
    }

    interface Profile {
        groups?: string[]
    }
}

declare module 'next-auth/jwt' {
    interface JWT {
        id_token?: string,
        provider?: string,
        access_token?: string,
        expires_at: number,
        refresh_token: string,
        error?: string,
        groups?: string[],
        decoded: {
            sub: string
            realm_access: RealmAccess
        },
    }
}

interface RealmAccess {
    roles: Array<string>;
}