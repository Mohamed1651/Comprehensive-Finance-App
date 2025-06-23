import { fetchWithAuth } from "../../utils/fetchWithAuth";

export const fetchUser = async (): Promise<any> => {
    try {
        const response = await fetchWithAuth("https://localhost:7233/api/user/me", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
        });

        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }

        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Error fetching user data:", error);
        throw error;
    }
}

export const fetchUsers = async(): Promise<any> => {
    try {
        const response = await fetchWithAuth("https://localhost:7233/api/user", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
        });

        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }

        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Error fetching user data:", error);
        throw error;
    }
}