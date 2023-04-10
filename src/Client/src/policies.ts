export const b2cPolicies = {
    names: {
        signUpSignIn: "B2C_1_susi",
        forgotPassword: "B2C_1_reset_password",
        editProfile: "B2C_1_edit_profile"
    },
    authorities: {
        signUpSignIn: {
            authority: "https://civicspaceb2c.b2clogin.com/civicspace-web-app.onmicrosoft.com/B2C_1_susi",
        },
        forgotPassword: {
            authority: "https://civicspaceb2c.b2clogin.com/civicspace-web-app.onmicrosoft.com/B2C_1_reset_password",
        },
        editProfile: {
            authority: "https://civicspaceb2c.b2clogin.com/civicspace-web-app.onmicrosoft.com/B2C_1_edit_profile"
        }
    },
    authorityDomain: "civicspaceb2c.b2clogin.com"
}