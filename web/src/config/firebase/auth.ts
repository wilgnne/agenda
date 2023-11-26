import { getAuth } from "firebase/auth";

import app from "./index.ts";

export const auth = getAuth(app);
