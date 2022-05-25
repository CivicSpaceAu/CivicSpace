function EditProfile() {
    return (
        <div>
        <h1>Edit Profile</h1>
        <form>
          <fieldset>
            <div className="form-group row">
              <label className="col-sm-2 col-form-label">Email</label>
              <div className="col-sm-10">
                            <input type="text" readOnly={true} className="form-control-plaintext" id="staticEmail" value="email@example.com" />
              </div>
            </div>
            <div className="form-group">
              <label className="form-label mt-4">Example textarea</label>
                        <textarea className="form-control" id="exampleTextarea" spellCheck={false} />
            </div>
            <button type="submit" className="btn btn-primary">Submit</button>
                </fieldset>
            </form>
        </div>
    );
}

export default EditProfile;