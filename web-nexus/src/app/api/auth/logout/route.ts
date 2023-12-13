import { authOptions } from "../[...nextauth]/route";
import { getServerSession } from "next-auth"
import { getIdToken, getAccessToken } from "../../../../../utils/sessionTokenAccessor";

export async function GET() {
    const session = await getServerSession(authOptions);


    if (session) {
        const idToken = await getIdToken();        
    
        var url = `${process.env.END_SESSION_URL}?id_token_hint=${idToken}&post_logout_redirect_uri=${encodeURIComponent(process.env.NEXTAUTH_URL || "")}`;

        try {
            const resp = await fetch(url, { method: "GET" });

        } catch (err) {
            return new Response(null, { status: 500 });
        }
    }

    return new Response(null, { status: 200 });
}