import { useEffect } from "react";
import { setAccessToken } from "../utils/tokenProvider";
import { useAuthToken } from "../contexts/AuthTokenProvider";

export const AuthInitializer = () => {
  const { accessToken } = useAuthToken();

  useEffect(() => {
    setAccessToken(accessToken);
  }, [accessToken]);

  return null; // this component just syncs the token
};
