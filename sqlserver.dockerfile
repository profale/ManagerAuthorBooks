FROM microsoft/mssql-server-linux:latest

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

COPY ./dbsettings /usr/src/app

USER root

ENV ACCEPT_EULA="Y"
ENV MSSQL_SA_PASSWORD="Teste12345678"

RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Teste12345678' -i /usr/src/app/setup.sql \
    && pkill sqlservr