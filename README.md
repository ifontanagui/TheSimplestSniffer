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

## Exemplos de Saídas
### IPv4 e TCP
```
################################################ IPv4 ################################################
                           From: 140.82.113.26:443 - To: 192.168.0.96:61081
                                      PacketLength - 52
                                     PayloadLength - 32
                                        Identifier - 56981
                                        TimeToLive - 46
                                               Payload
                                              Type - Tcp
                                    SequenceNumber - 2359957511
                              AcknowledgmentNumber - 2405531688
                                        WindowSize - 74
                                             Flags
                                             Ugent - 0
                                    Acknowledgment - 1
                                              Push - 0
                                             Reset - 0
                                               Syn - 0
                                               Fin - 0
```
### IPv4 e UDP
```
################################################ IPv4 ################################################
                         From: 192.168.0.128:52004 - To: 255.255.255.255:6667
                                      PacketLength - 290
                                     PayloadLength - 270
                                        Identifier - 20104
                                        TimeToLive - 255
                                               Payload
                                              Type - Udp
                                          Checksum - 51178
```
### IPv6 e TCP
```
################################################ IPv6 ################################################
 From: 2804:14c:7d80:8e82:88b2:c49b:ffc:25cf:61041 - To: 2606:50c0:8000::154:443
                                      PacketLength - 61
                                     PayloadLength - 21
                                      TrafficClass - 0
                                          HopLimit - 64
                                               Payload
                                              Type - Tcp
                                    SequenceNumber - 235794486
                              AcknowledgmentNumber - 841923879
                                        WindowSize - 255
                                             Flags
                                             Ugent - 0
                                    Acknowledgment - 1
                                              Push - 0
                                             Reset - 0
                                               Syn - 0
                                               Fin - 0
```
### IPv6 e UDP
```
################################################ IPv6 ################################################
                 From: 2800:3f0:4001:817::200a:443 - To: 2804:14c:7d80:8e82:88b2:c49b:ffc:25cf:63977
                                      PacketLength - 74
                                     PayloadLength - 34
                                      TrafficClass - 0
                                          HopLimit - 55
                                               Payload
                                              Type - Udp
                                          Checksum - 30114
```
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