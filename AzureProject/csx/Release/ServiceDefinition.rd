<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AzureProject" generation="1" functional="0" release="0" Id="d1ef7b78-0e86-49d9-9b99-b69eef44a3e1" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="AzureProjectGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WCFServices:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/AzureProject/AzureProjectGroup/LB:WCFServices:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="WCFServices:Endpoint2" protocol="https">
          <inToChannel>
            <lBChannelMoniker name="/AzureProject/AzureProjectGroup/LB:WCFServices:Endpoint2" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WCFServicesInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/AzureProject/AzureProjectGroup/MapWCFServicesInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WCFServices:Endpoint1">
          <toPorts>
            <inPortMoniker name="/AzureProject/AzureProjectGroup/WCFServices/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:WCFServices:Endpoint2">
          <toPorts>
            <inPortMoniker name="/AzureProject/AzureProjectGroup/WCFServices/Endpoint2" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWCFServicesInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/AzureProject/AzureProjectGroup/WCFServicesInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WCFServices" generation="1" functional="0" release="0" software="D:\Programação\AzureProject\AzureProject\csx\Release\roles\WCFServices" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <inPort name="Endpoint2" protocol="https" portRanges="8080" />
            </componentports>
            <settings>
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WCFServices&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WCFServices&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Endpoint2&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/AzureProject/AzureProjectGroup/WCFServicesInstances" />
            <sCSPolicyUpdateDomainMoniker name="/AzureProject/AzureProjectGroup/WCFServicesUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/AzureProject/AzureProjectGroup/WCFServicesFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WCFServicesUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WCFServicesFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WCFServicesInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="7698eb29-9f4b-4afc-ae98-e589be7ac01b" ref="Microsoft.RedDog.Contract\ServiceContract\AzureProjectContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="15e448a4-269b-4bb6-a835-c065f807c187" ref="Microsoft.RedDog.Contract\Interface\WCFServices:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/AzureProject/AzureProjectGroup/WCFServices:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="a0f134b4-5b2c-43ae-ac7b-29e6642940bc" ref="Microsoft.RedDog.Contract\Interface\WCFServices:Endpoint2@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/AzureProject/AzureProjectGroup/WCFServices:Endpoint2" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>