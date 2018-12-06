<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                              xmlns:c="http://my.company.com"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="c:commercials">
    <xsl:element name="Companies">
      <xsl:apply-templates select="c:commercial"/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="c:commercial">
    <xsl:element name="Company">
      <xsl:element name="Name">
        <xsl:value-of select="@company"/>
      </xsl:element>
      <xsl:element name="Logo">
        <xsl:value-of select="c:logo"/>
        <xsl:value-of select="c:ourlogo"/>
      </xsl:element>
      <xsl:element name="Phone">
        <xsl:value-of select="c:telephones/c:telephone"/>
        <xsl:value-of select="c:telephone"/>
      </xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>