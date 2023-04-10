/**
 * To learn more about user flows, visit: https://docs.microsoft.com/en-us/azure/active-directory-b2c/user-flow-overview
 * To learn more about custom policies, visit: https://docs.microsoft.com/en-us/azure/active-directory-b2c/custom-policy-overview
 */
export const b2cPolicies = {
    names: {
        signUpSignIn: "B2C_1_signupsignin",
        forgotPassword: "B2C_1_forgotpassword",
        editProfile: "B2C_1_editprofile"
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