import { useCallback } from "react";
import { GoogleAuthProvider, signInWithPopup } from "firebase/auth";
import { auth } from "./config/firebase/auth.ts";

const App = () => {
  const handleGoogleSignIn = useCallback(async () => {
    // Sign in using a popup.
    const provider = new GoogleAuthProvider();
    const result = await signInWithPopup(auth, provider);

    // The signed-in user info.
    const user = result.user;

    console.log({ user, token: await user.getIdToken() });
  }, []);

  return <button onClick={() => handleGoogleSignIn()}>Logar com google</button>;
};

export default App;
