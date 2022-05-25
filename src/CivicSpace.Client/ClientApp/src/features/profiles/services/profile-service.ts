import { useGetNodeQuery } from "../../../services/node-api";
import { Profile, nodeToProfile, profileToNode, emptyProfile } from "../types/profile";

export function useGetProfile(id: string): Profile {
    const { data, error, isLoading } = useGetNodeQuery(id);
    return data ? nodeToProfile(data) : emptyProfile();
}
