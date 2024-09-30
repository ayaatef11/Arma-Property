import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'MyBookStore',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44344/',
    redirectUri: baseUrl,
    clientId: 'MyBookStore_App',
    responseType: 'code',
    scope: 'offline_access MyBookStore',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44344',
      rootNamespace: 'MyBookStore',
    },
  },
} as Environment;
