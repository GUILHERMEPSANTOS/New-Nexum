import { AuthOptions } from "next-auth";
import NextAuth from "next-auth/next";
import KeycloakProvider from "next-auth/providers/keycloak";

import { jwtDecode } from "jwt-decode";

import { encrypt } from "../../../../../utils/encryption";

export const authOptions: AuthOptions = {
    providers: [
        KeycloakProvider({
            clientId: `${process.env.KEYCLOAK_ID}`,
            clientSecret: `${process.env.KEYCLOAK_SECRET}`,
            issuer: `${process.env.KEYCLOAK_ISSUER}`,
            wellKnown: `${process.env.KEYCLOAK_WELL_KNOWN}`
        })
    ],
    callbacks: {
        async jwt({ token, account, profile }) {
            const nowTimeStamp = Math.floor(Date.now() / 1000);        

            if (account) {
                token.decoded = jwtDecode(account?.access_token || "");
                token.access_token = account.access_token;
                token.id_token = account.id_token;
                token.expires_at = account.expires_at || new Date().getDate();
                token.refresh_token = account.refresh_token || "";
                token.groups = profile?.groups || []

                return token;
            } else if (nowTimeStamp < (token?.expires_at as number)) {
                // token has not expired yet, return it
                return token;
            } else {
                // token is expired, try to refresh it
                console.log("Token expirou!");

                return token;
            }
        },

        async session({ session, token }) {
            session.access_token = encrypt(token.access_token || "");            
            session.id_token = encrypt(token.id_token || "");                
            session.roles = token.decoded.realm_access.roles;
            session.error = token.error;
            session.groups = token.groups;
        
            return session;
        }
    }
};

const handler = NextAuth(authOptions);

export { handler as GET, handler as POST };