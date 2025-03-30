# TheSimplestSniffer
## Descrição
O TheSimplestSniffer é um network sniffer de terminal que, utilizando os pacotes: ***[SharpPcap](https://www.nuget.org/packages/SharpPcap)*** (*v6.3.0*) e ***[PacketDotNet](https://www.nuget.org/packages/packetdotnet/)*** (*v1.4.7*), captura e apesenta pacotes *IPv4* e *IPv6*, com protocolos *TCP* e *UPD*
## Classes
### App
Classe responsável pela captura e exposição dos pacotes.
### Make
Classe responsável por receber os pacotes capturados e processa-los.
### BaseClass
Classe abstrata que obriga todas as classes herdeiras a reimplementarem o método: ***ToString***.
### Payload
Classe abstrata que herda a classe: *BaseClass*. Esta possui os atributos básicos para servir como base para todas as classes que representam payloads.
### TCP
Esta classe, que herdas os atributos da classe ***Payload***, adicionando os atributos necessários para representação de um payload do tipo: **TCP**.
### UDP
Esta classe, que herdas os atributos da classe ***Payload***, adicionando os atributos necessários para representação de um payload do tipo: **UDP**.
### Protocol
Classe abstrata que herda a classe: *BaseClass* e espera um parâmetro ***T***, que deve ser obrigatoriamente do tipo ***Payload*** ou de um de seus herdeiros. Esta possui os atributos básicos para servir como base para todas as classes que representam um pacote.
### IPv4
Esta classe, que herdas os atributos da classe ***Protocol***, adicionando os atributos necessários para representação de um pacote do tipo: **IPv4**.
### IPv6
Esta classe, que herdas os atributos da classe ***Protocol***, adicionando os atributos necessários para representação de um pacote do tipo: **IPv6**.

<img src="https://raw.githubusercontent.com/GuilhermeFontana/TheSimplestSniffer/refs/heads/Development/Docs/Images/ClassDiagram.png" alt="Diagrama de classes" width="1000" height="500" />

## Fluxograma de Classes

<img src="https://raw.githubusercontent.com/GuilhermeFontana/TheSimplestSniffer/refs/heads/Development/Docs/Images/Fluxogramas.png?token=GHSAT0AAAAAADBAAJKAUCAIF3VWB6PWYLJGZ7IVFYQ" alt="Diagrama de classes" width="1000" height="300" />

## Referencias
### Classes e Métodos Importantes
* **PacketArrivalEventHandler**: Função delegadora de função, para o evento de chegada de pacotes.
* **PacketCapture**: Classe com o pacote capturado bruto.
* **PacketCapture.GetPacket**: Método que devolve o pacote capturado bruto.
* **LibPcapLiveDeviceList**: Classe que captura os pacotes driver de rede dispositivo.  
* **LibPcapLiveDeviceList.Instance**: Atributo que captura e disponibiliza os driver de rede do dispositivo.  
* **LibPcapLiveDevice**: Classe de driver de rede.
* **Packet.ParsePacket**: Método que devolve o pacote capturado pré processado.
### Links
* https://sharppcap.sourceforge.net/htmldocs/index.html
* https://sharppcap.sourceforge.net/htmldocs/SharpPcap.LibPcap/index.html
* https://sharppcap.sourceforge.net/htmldocs/SharpPcap/index.html