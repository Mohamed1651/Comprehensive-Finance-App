import { useEffect, useState } from "react";
import { useAuthToken } from "../contexts/AuthTokenProvider";
import { fetchUsers } from "../services/user/UserService";
import User from "../types/User";

const UserList: React.FC = () => {
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
                    const result = await fetchUsers(); 
                    setData(result);
                } catch (err: any){
                    setError(err.message);
                }        
            };
        fetchData();
    }, [accessToken]);

    if (error) return <div>Error: {error}</div>;
    if (!data) return <div>Loading...</div>;
    return (
        <div>
            Welkom {data[0].name}
        </div>
      );

}

export default UserList;