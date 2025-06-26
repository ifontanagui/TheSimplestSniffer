
<div>
  <strong style="font-size: 40px"> 🔍 TheSimplestSniffer</strong>
  <br/>
  <br/>
TheSimplestSniffer – Sniffer de Rede Simples em Terminal
TheSimplestSniffer é uma ferramenta de análise de pacotes de rede (sniffer), desenvolvida para uso em terminal. Ela permite capturar e exibir informações detalhadas de pacotes que trafegam pela rede, com suporte aos protocolos <strong>IPv4, IPv6, TCP e UDP</strong>. A aplicação foi desenvolvida utilizando as bibliotecas <strong>SharpPcap (v6.3.0)</strong> e <strong>PacketDotNet (v1.4.7)</strong>, amplamente utilizadas em .NET para captura e análise de pacotes.

<br/>

Ele é um programa de terminal que observa o que está acontecendo na sua rede em tempo real. Ele capta e mostra as mensagens (chamadas de "pacotes") que os computadores, celulares e outros dispositivos enviam e recebem pela internet. Como um detetive da rede, olha para todos os detalhes do tráfego para mostrar quem está se comunicando com quem, qual tipo de mensagem está sendo enviada, e como essas mensagens estão estruturadas.

<br />

O TheSimplestSniffer é um programa simples, direto e muito útil para entender o que está acontecendo dentro da sua rede. Ele mostra tudo de forma clara no terminal, sendo perfeito para aprender, investigar e explorar como a internet realmente funciona.

  
  <div>
    <br/>
    <hr/>
    <br/>
    <strong style="font-size: 25px">Como Utilizar</strong>
    
1. Execute o Sniffer (<strong>TheSimplestSniffer.exe</strong>)

2. Assim que o programa iniciar, ele vai listar automaticamente todos os dispositivos de rede disponíveis no seu computador, e pedir que você escolha um.

3. Digite o número do dispositivo desejado e pressione Enter.
```
Dispositivos disponíveis para captura:
1) ...
2) ...
3) ...
Selecione um dispositivo:
```
4. O sniffer começará imediatamente a capturar os pacotes de rede que passam pela interface escolhida. Você verá no terminal várias informações detalhadas.

5. Enquanto o sniffer estiver ativo, você pode continuar usando a internet normalmente. A ferramenta vai capturar tudo o que passar pela interface de rede.

6. Para encerrar o processo de captura, basta pressionar:
```
Ctrl + C
```
  </div>

  <br/>
  <hr>
  <div style="display: flex;center;flex-direction:column">
    <strong style="font-size: 25px">📦 Arquitetura e Classes</strong>
    <br/>    
  A estrutura do sistema é organizada de forma modular e orientada a objetos, promovendo clareza e facilidade de manutenção. Abaixo, um resumo das principais classes:

  🔹 Program
  Classe principal do projeto. Responsável por inicializar a aplicação e delegar o controle para a captura de pacotes.

  🔹 App
  Controla o fluxo principal da aplicação. Realiza a captura dos pacotes da rede e os exibe no terminal, formatados de maneira clara e organizada.

  🔹 Make
  Classe utilitária com métodos estáticos usados para instanciar objetos representando pacotes de rede a partir dos dados capturados.

  🔹 BaseClass
  Classe abstrata que serve como base para todas as outras classes do sistema. Define atributos e métodos comuns.

  🔹 Protocol e Payload
  Herdam de BaseClass. Protocol representa protocolos da camada de rede (como IPv4 ou IPv6), enquanto Payload representa a carga útil, geralmente relacionada à camada de transporte (TCP/UDP).

  🔹 TCP e UDP
  São subclasses de Protocol. Cada uma representa os respectivos protocolos de transporte, contendo informações específicas como portas, checksums e flags.

  🔹 IPv4 e IPv6
  Herdam de Protocol e adicionam atributos específicos de cada versão do protocolo IP, como TOS, TTL, FlowLabel, etc.
  <div>
    <strong style="font-size: 18px">Diagramas</strong>
    <br />
    <br />
    <div style="display: flex;gap: 20px; flex-direction: row;display-content:center">
      <img src="Docs\Images\Fluxogramas.png" alt="Diagrama de classes" width="27%" height="600px"/>
      <img src="Docs\Images\ClassDiagram.png" alt="Diagrama de classes" width="73%" height="600px" />
    </div>
  </div>
  <div>
  <br/>
  <hr/>
  <br />
  </div>

  <div width="80%">
    <strong style="font-size: 25px">📤 Exibição das Informações, com Exemplos</strong>
   
O sniffer é capaz de imprimir uma representação textual detalhada dos pacotes, com divisões bem formatadas e legíveis no terminal.
    <br/>
    
<strong style="font-size: 18px">📄 IPv4 com TCP</strong>

Exibe informações detalhadas como endereços IP de origem/destino, portas, identificador de fragmentos, TTL, além das flags TCP como SYN, ACK, e Sequence Number.

``` 
########################################################## IPv4 ##########################################################
                                  From Address: 192.168.0.96 - To Address: 52.5.76.173
                                            From Port: 57163 - To Port: 8347
                                                         IHL - 5
                                                         TOS - 0
                                                  TotalLenth - 52
                                              Identification - 40794
                                                       Flags
                                                    Reserved - 0
                                              Don't Fragment - 1
                                              More Fragments - 0
                                             Fragment Offset - 0
                                                         TTL - 128
                                                    Checksum - 6575
                                                    Protocol - 5
                                                         Payload
                                                        Type - Tcp
                                              SequenceNumber - 3300238699
                                        AcknowledgmentNumber - 0
                                                  DataOffset - 8
                                                  WindowSize - 65535
                                                    Checksum - 49997
                                              Urgent Pointer - 0
                                                       Flags
                                                       Ugent - 0
                                              Acknowledgment - 0
                                                        Push - 0
                                                       Reset - 0
                                                         Syn - 1
                                                         Fin - 0
```

<strong style="font-size: 18px">📄 IPv4 com UDP</strong>

Similar ao exemplo acima, mas para o protocolo UDP. Mostra portas de origem/destino, comprimento e checksum, com menos campos em relação ao TCP.

```
########################################################## IPv4 ##########################################################
                                 From Address: 192.168.0.128 - To Address: 255.255.255.255
                                            From Port: 52004 - To Port: 6667
                                                         IHL - 5
                                                         TOS - 0
                                                  TotalLenth - 290
                                              Identification - 63062
                                                       Flags
                                                    Reserved - 0
                                              Don't Fragment - 0
                                              More Fragments - 0
                                             Fragment Offset - 0
                                                         TTL - 255
                                                    Checksum - 844
                                                    Protocol - 5
                                                         Payload
                                                        Type - Udp
                                                      Length - 270
                                                    Checksum - 19488
```

<strong style="font-size: 18px">📄 IPv6 com TCP</strong>

Inclui os campos exclusivos do IPv6 como Traffic Class, Flow Label e Hop Limit, além das informações detalhadas do TCP.

```
########################################################## IPv6 ##########################################################
        From Address: 2804:14c:7d84:8da2:4d66:205b:a247:7fac - To Address: 2620:1ec:bdf::33
                                            From Port: 57136 - To Port: 443
                                                TrafficClass - 0
                                                   FlowLabel - 747532
                                               PayloadLength - 20
                                                  NextHeader - Tcp
                                                    HopLimit - 64
                                                         Payload
                                                        Type - Tcp
                                              SequenceNumber - 1923822921
                                        AcknowledgmentNumber - 815765707
                                                  DataOffset - 5
                                                  WindowSize - 255
                                                    Checksum - 63588
                                              Urgent Pointer - 0
                                                       Flags
                                                       Ugent - 0
                                              Acknowledgment - 1
                                                        Push - 0
                                                       Reset - 0
                                                         Syn - 0
                                                         Fin - 0
```

<strong style="font-size: 18px">📄 IPv6 com UDP</strong>

Assim como os demais, mostra os campos do cabeçalho IPv6 e as informações essenciais do protocolo UDP.

```
########################################################## IPv6 ##########################################################
        From Address: 2804:14c:7d84:8da2:4d66:205b:a247:7fac - To Address: 2804:14d:1:0:181:213:132:2
                                            From Port: 62852 - To Port: 53
                                                TrafficClass - 0
                                                   FlowLabel - 415965
                                               PayloadLength - 45
                                                  NextHeader - Udp
                                                    HopLimit - 64
                                                         Payload
                                                        Type - Udp
                                                      Length - 45
                                                    Checksum - 62084
```
  </div>
  <div>
    <div>
      <br/>
      <hr/>
      <br/>
      <strong style="font-size: 25px">Referências</strong>
      <br/>
      <br/>
      <strong style="font-size: 18px">Classes e Métodos Importantes</strong>
      <ul>
        <li style="display:flex">
          <p style="color: orange">PacketArrivalEventHandler: &nbsp;</p>
          <p>Função delegadora de função, para o evento de chegada de pacotes. </p>
        </li>
        <li style="display:flex"> 
          <p style="color: orange">PacketCapture: &nbsp;<p>
          <p>Classe com o pacote capturado bruto.<p> 
        </li>
        <li style="display:flex"> 
          <p style="color: orange">PacketCapture.GetPacket: &nbsp;<p>
          <p>Método que devolve o pacote capturado bruto.<p> 
        </li>
        <li style="display:flex"> 
          <p style="color: orange">LibPcapLiveDeviceList: &nbsp;<p>
          <p>Classe que captura os pacotes driver de rede dispositivo.  <p> 
        </li>
        <li style="display:flex"> 
          <p style="color: orange">LibPcapLiveDeviceList.Instance: &nbsp;<p>
          <p>Atributo que captura e disponibiliza os driver de rede do dispositivo.  <p> 
        </li>
        <li style="display:flex"> 
          <p style="color: orange">LibPcapLiveDevice: &nbsp;<p>
          <p>Classe de driver de rede.<p> 
        </li>
        <li style="display:flex"> 
          <p style="color: orange">Packet.ParsePacket: &nbsp;<p>
          <p>Método que devolve o pacote capturado pré processado.<p> 
        </li>
      <ul>
    </div>
    <br/>
    <strong style="font-size: 18px">Campos</strong>
    <br/>
    <br/>
    <div style="display: flex;gap: 50px; flex-direction: row;display-content:center">
      <div>
        <img src="https://arquivo.devmedia.com.br/REVISTAS/infra/imagens/03/03_IPv6/image005.png" alt="IPv46 Headers" width="100%" height="500" />
      </div>
      <div>
        <img src="https://dhg1h5j42swfq.cloudfront.net/2023/10/23191655/imagem-inicial-4.png" alt="TCP_UDP Headers" width="100%" height="500" />
      </div>
    </div>
  </div>
  <br/>
  <br/>
  <strong style="font-size: 18px">Links</strong>
  <ul>
    <li>
      <a href="https://sharppcap.sourceforge.net/htmldocs/index.html">https://sharppcap.sourceforge.net/htmldocs/index.html</a>
    </li>
    <li> 
      <a href="https://sharppcap.sourceforge.net/htmldocs/SharpPcap.LibPcap/index.html">https://sharppcap.sourceforge.net/htmldocs/SharpPcap.LibPcap/index.html</a>
    </li>
    <li>
      <a href="https://sharppcap.sourceforge.net/htmldocs/SharpPcap/index.html">https://sharppcap.sourceforge.net/htmldocs/SharpPcap/index.html</a>
    </li>
    <li> 
      <a href="https://www.gta.ufrj.br/ensino/eel879/trabalhos_vf_2009_2/priscilla/images/cabecalho.jpg">https://www.gta.ufrj.br/ensino/eel879/trabalhos_vf_2009_2/priscilla/images/cabecalho.jpg</a>
    </li>
    <li> 
      <a href="https://dhg1h5j42swfq.cloudfront.net/2023/10/23191655/imagem-inicial-4.png">https://dhg1h5j42swfq.cloudfront.net/2023/10/23191655/imagem-inicial-4.png</a>
    </li>
  </ul>
</div>
