FROM node:8

# File Author / Maintainer
LABEL authors="Sean Przybyla <sean@darksharddesign.co.uk>"

# Copy app source
COPY ./dist .

# Copy package.json
COPY . .

# Set work directory to /www
WORKDIR .

# set your port
ENV PORT 9090

# expose the port to outside world
EXPOSE  9090

# start command as per package.json
CMD ["npm", "start"]