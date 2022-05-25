import { useGetProfile } from "../services/profile-service";

function ViewProfile() {
    const profile = useGetProfile('1');
    
    return (
        <h1>Profile</h1>
    );
}

export default ViewProfile;