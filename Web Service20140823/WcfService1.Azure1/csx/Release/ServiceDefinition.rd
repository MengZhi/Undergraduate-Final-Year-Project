﻿<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WcfService1.Azure1" generation="1" functional="0" release="0" Id="68d20d71-a63d-4508-9700-7ec9be19adfa" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WcfService1.Azure1Group" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WcfService1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/LB:WcfService1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WcfService1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/MapWcfService1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WcfService1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/MapWcfService1Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WcfService1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/WcfService1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWcfService1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/WcfService1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWcfService1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/WcfService1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WcfService1" generation="1" functional="0" release="0" software="C:\Users\ZHI MENG\Documents\Visual Studio 2013\Projects\WcfService1\WcfService1.Azure1\csx\Release\roles\WcfService1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WcfService1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WcfService1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/WcfService1Instances" />
            <sCSPolicyUpdateDomainMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/WcfService1UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/WcfService1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WcfService1UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WcfService1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WcfService1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="5b94bd36-1d54-4ba3-8683-9c708e11fb63" ref="Microsoft.RedDog.Contract\ServiceContract\WcfService1.Azure1Contract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="6187e08d-ccd6-4902-ba8a-0047bf85eef1" ref="Microsoft.RedDog.Contract\Interface\WcfService1:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WcfService1.Azure1/WcfService1.Azure1Group/WcfService1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>