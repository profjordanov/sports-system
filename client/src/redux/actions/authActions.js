import * as ActionTypes from "./actionTypes";
import * as authApi from "../../api/authService";

export function logoutSuccess() {
    return { type: ActionTypes.LOGOUT_SUCCESS };
}

export function login(credentials) {
    return function (dispatch) {
        return authApi
            .login(credentials)
            .then(token => {
                localStorage.setItem("access_token", token.tokenString);
            })
            .catch(error => {
                dispatch(logout());
                throw error;
            });
    };
}

export function logout() {
    return function(dispatch) {
        authApi.logout().then(_ => {
            dispatch(logoutSuccess());
        });
    };
}