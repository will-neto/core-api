import { Injectable } from "@angular/core";
import { CanLoad, Route, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

@Injectable()
export class AuthGuard implements CanLoad, CanActivate {
    
    user = { admin: true, logged: false };
    
    canActivate() {
        return this.user.logged;
    }
    
    canLoad() {
        return this.user.admin;
    }
}