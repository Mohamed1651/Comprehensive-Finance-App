/* eslint-disable @typescript-eslint/no-explicit-any */
// src/components/FetchData.tsx
import React, { useEffect, useState } from "react";
import { fetchUser } from "../services/user/UserService.ts"
import { useAuthToken } from "../contexts/AuthTokenProvider";

const UserDetails: React.FC = () => {
    const { accessToken, refreshToken } = useAuthToken();
    const [data, setData] = useState<any>(null);
    const [error, setError] = useState<string | null>(null);


    useEffect(() => {
        const fetchData = async () => {
                if (!accessToken) {
                    await refreshToken();
                    return;
                }
                try {
                    const result = await fetchUser(); 
                    setData(result);
                } catch (err: any){
                    setError(err.message);
                }        
            };
        fetchData();
    }, [accessToken]);

    if (error) return <div>Error: {error}</div>;
    if (!data) return <div>Loading...</div>;

    return <div></div>;
};

export default UserDetails;
