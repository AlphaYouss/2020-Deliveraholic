FROM node:13.12.0-alpine

WORKDIR /app

COPY Deliveraholic_frontend/package.json /app

RUN npm install 

COPY Deliveraholic_frontend/. /app

CMD ["npm", "run", "start"] 