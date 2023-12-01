"use client";
import { useTheme } from "next-themes";
import { Button } from "./ui/button";

export default function ToggleTheme() {
  const { theme, setTheme } = useTheme();

  const handleTheme = () => {
    if (theme !== "light") {
      return setTheme("light");
    }
    return setTheme("dark");
  };
  return <Button onClick={handleTheme}>Tema</Button>;
}
