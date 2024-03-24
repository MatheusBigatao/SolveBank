import { CanActivateFn, Router } from '@angular/router';

export const externalAuthenticationGuard: CanActivateFn = (route, state) => {
  const routeAuthorize = new Router;
  const userLogged = localStorage.getItem('userLogged')
  if (!userLogged) {
    routeAuthorize.navigateByUrl('/external/login')
    return false
  } else {
    return true;
  }
};
