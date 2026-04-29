Webb-API byggt med REST-arkitektur.

ENDPOINTS:

Hämta alla användare i systemet
GET /api/WebAPI

Hämta intressen för specifik användare
GET /api/WebAPI/{id}/interests 

Hämta alla länkar kopplade till en specifik användare
GET /api/WebAPI/{id}/links

Lägg till intresse för användare
POST /api/WebAPI/{id}/interests/{interestId}

Lägg till nya länkar för en specifik användare och ett specifikt intresse
POST /api/WebAPI/{id}/interests/{interestId}/links

Testat via Swagger
