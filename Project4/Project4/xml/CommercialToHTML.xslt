<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                              xmlns:c="http://my.company.com"
>
    <xsl:output method="html"/>

    <xsl:template match="/">
      <h3>Commercials</h3>
      <div class="commercials">
          <xsl:apply-templates select="//c:commercials"/>
        </div>
    </xsl:template>
    <xsl:template match="c:commercial">
      <div class="commercial">
        <h3>
          <xsl:value-of select="@company"/>
        </h3>
        <img class="logo-img" alt="commercial image">
          <xsl:attribute name="src">
            logo-img/<xsl:value-of select="c:logo"/>
            <xsl:value-of select="c:ourlogo"/>
          </xsl:attribute>
        </img>
        <p>
          Contact: 
          <xsl:value-of select="c:telephones/c:telephone"/>
          <xsl:value-of select="c:telephone"/>
        </p>
      </div>
    </xsl:template>
</xsl:stylesheet>
