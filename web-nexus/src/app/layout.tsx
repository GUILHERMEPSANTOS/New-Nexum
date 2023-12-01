import { PropsWithChildren } from "react";

import type { Metadata } from "next";
import { Roboto } from "next/font/google";
import "./globals.css";
import { ThemeProviderNexus } from "@/providers/themeProviderNexus";

const roboto = Roboto({
  subsets: ["latin"],
  weight: ["100", "400", "700", "900"],
});

export const metadata: Metadata = {
  title: "nexus",
  description: "Generated by create next app",
};

export default function RootLayout({ children }: PropsWithChildren) {
  return (
    <html lang="pt">
      <body className={roboto.className}>
        <ThemeProviderNexus attribute="class" defaultTheme="system" enableSystem>
          {children}
        </ThemeProviderNexus>
      </body>
    </html>
  );
}
