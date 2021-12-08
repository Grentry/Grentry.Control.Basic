
# Grentry.Control.Basic

Grentry.Control.Basic is a simple example for an implementation for a Grentry Controller Device. It provides a Backend (.net) to handle the communication with the
Grentry.Device.ControllerApi using the Grentry.SDK.Net (https://github.com/Grentry/Grentry.SDK.Net) and a Frontend (Angular) to interact
with the user.





## Installation

On your Grentry Controller Device, connect with ssh then edit the docker-compose.yml. 

docker-compose.yml
```yml
version: '3.4'

services:
  grentrycontrolbasic:
    image: ladartha/grentry-control-basic:latest
    restart: always
    environment:
      - Control:BaseUrl=grentrydevicecontrollerapi:5000
    ports:
      - "4444:80"
    depends_on:
      - grentrydevicecontrollerapi
    
  
  grentrydevicecontrollerapi:
    image: gitlab.koglump.com:5050/grentry/device/gentry.device.controllerapi:latest
    restart: always
    privileged: true
    ports:
      - "5000:80"
```

Starting with docker-compose

```bash
sudo docker-compose up -d
```

Restart Device

```bash
sudo reboot
```
## Usage/Examples

After reboot the application should be visible and ready to use


## License

Grentry.SDK.Net is licensed under the MIT license. [MIT](https://choosealicense.com/licenses/mit/)

