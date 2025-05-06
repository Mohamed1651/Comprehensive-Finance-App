export interface AuthTokenContextType {
    accessToken: string | null;
    refreshToken: () => Promise<void>;
}
