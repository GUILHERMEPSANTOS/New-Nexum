"use client"

import { useSession, signIn, signOut } from "next-auth/react";
import { Button } from "./ui/button";

async function keycloakSessionLogOut() {
    try {
        await fetch("/api/auth/logout", { method: "GET" });
    } catch (err) {
        console.error(err);
    }
}

export default function SingIn() {
    const { data: session, status } = useSession();


    if (status == "loading") {
        return <div className="my-3">Loading...</div>;
    } else if (session) {
        return (
            <div className="my-3">
                Entrar <span className="text-yellow-100">{session.user.email}</span>{" "}
                <button
                    className="bg-blue-900 font-bold text-white py-1 px-2 rounded border border-gray-50"
                    onClick={() => signOut({ callbackUrl: "/" })}>
                    Sair
                </button>
            </div >
        );
    }

    return (
        <Button className='hidden md:block px-6' variant="ghost" onClick={() => signIn("keycloak", { redirect: true, callbackUrl: "/home-freelancer" })}>Entrar</Button>
    );
}