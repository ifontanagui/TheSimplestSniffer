<div>
  <strong style="font-size: 40px">TheSimplestSniffer</strong>
  <br>
  <br>
  <div style="display=flex; flex-direction:row">
      O TheSimplestSniffer é um network sniffer de terminal que, utilizando os pacotes: &nbsp; <a href="https://www.nuget.org/packages/SharpPcap">SharpPcap (*v6.3.0*)</a> e <a href="https://www.nuget.org/packages/packetdotnet/">PacketDotNet (*v1.4.7*)</a>, captura e apesenta pacotes <strong>IPv4</strong> e <strong>IPv6</strong>, com protocolos <strong>TCP</strong> e <strong>UPD</strong>
  </div>
  <br/>
  <br/>
  <hr>
  <div style="display: flex;center;flex-direction:column">
    <strong style="font-size: 25px">Classes</strong>
    <br/>
    <div style="display: flex;gap: 50px; flex-direction: row;display-content:center">
      <img src="Docs\Images\Fluxogramas.png" alt="Diagrama de classes" width="60%" height="600px"/>
      <div style="width: 40%">
        <strong style="font-size: 17px">Program</strong>
        <p>Classe responsável pela inicialização do programa.</p>
        <strong style="font-size: 17px">App</strong>
        <p>Classe responsável pela captura e exposição dos pacotes.</p>
        <strong style="font-size: 17px">Make</strong>
        <p>Classe utilitária estática responsável por instanciar objetos baseados nos pacotes de rede recebidos.</p>
        <hr>
        <strong style="font-size: 17px">BaseClass</strong>
        <p>Classe base abstrata de todas as outras.</p>
        <strong style="font-size: 17px">Payload e Protocol</strong>
        Herdam de BaseClass.
        </strong style="font-size: 17px">TCP e UDP</strong>
        <p>Herdam de Protocol<T>, onde T é uma subclasse de Payload.</p>
        <strong style="font-size: 17px">IPv4 e IPv6</strong>
        <p>Esta classe, que herdas os atributos da classe ***Protocol***, adicionando os atributos necessários para representação de um pacote do tipo: **IPv6**.</p>
      </div>
    </div>
  </div>
  <br/>
  <br/>
  <div style="display: flex;center;flex-direction:column">
    <strong style="font-size: 25px">Diagrama</strong>
    <br/>
    <img src="Docs\Images\ClassDiagram.png" alt="Diagrama de classes" width="100%" height="700" />
  </div>
  <br/>
  <br/>
  <hr/>
  <br/>

  <div width="80%">
    <strong style="font-size: 25px">Exemplos de Saída</strong>
    <br/>
    <br/>
    <strong style="font-size: 18px">IPv4 e TCP</strong>
    <br/>
    <br/>

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
  <br/>
  <br/>
  <strong style="font-size: 18px">IPv4 e UDP</strong>
  <br/>
  <br/>

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
  <br/>
  <br/>
  <strong style="font-size: 18px">IPv6 e TCP</strong>
  <br/>
  <br/>

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
  <br/>
  <br/>
  <strong style="font-size: 18px">IPv6 e UDP</strong>
  <br/>
  <br/>

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
