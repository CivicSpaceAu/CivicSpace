import { useState } from 'react';
import { emptyProfile, profileToNode } from '../types/profile';
import { useGetTokenQuery } from '../../../services/token-api';
import { useGetNodeQuery, useCreateNodeMutation } from '../../../services/node-api';

export function EditProfile(props: any) {
    const [description, setDescription] = useState("");

    var tokenRequest = {
        email: 'admin@root.com',
        password: '123Pa$$word!'
    };
    const { currentData, isFetching, isError } = useGetTokenQuery(tokenRequest);

    const [createNode, createNodeResult] = useCreateNodeMutation();
    const handleSubmit = (event: any) => {
        event.preventDefault();

        alert('1');
        var profile = emptyProfile();
        alert('2');
        profile.description = description;
        alert('3');
        var node = profileToNode(profile);

        createNode({
            token: currentData?.token,
            node: node
        });
    }

    return (
        <div>
            <h1>Edit Profile</h1>
            <form onSubmit={ handleSubmit }>
                <fieldset>
                    <div className="form-group">
                        <textarea
                            className="form-control"
                            id="description"
                            spellCheck={false}
                            value={ description }
                            onChange={ e => setDescription(e.target.value) }
                        />
                    </div>
                    <button type="submit"
                        className="btn btn-primary">
                        Submit
                    </button>
                </fieldset>
            </form>
        </div>
    );
}

export default EditProfile;