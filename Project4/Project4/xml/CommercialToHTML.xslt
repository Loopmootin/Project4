<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                              xmlns:c="http://my.company.com"
>
    <xsl:output method="html"/>

    <xsl:template match="/">
      <h3>List of Commercials</h3>
      <table border="1">
        <tr>
          <th>Owner</th>
          <th>Webpage</th>
          <th>Logo</th>
          <th>Phone</th>
        </tr>
        <xsl:apply-templates select="//c:commercials"/>
      </table>
    </xsl:template>
    <xsl:template match="c:commercial">
      <tr>
        <td>
          <xsl:value-of select="c:director"/>
          <xsl:value-of select="c:owner"/>
          <xsl:value-of select="c:directors/c:chiefdirector"/>
          <xsl:value-of select="c:directors/c:director"/>
        </td>
        <td>
          <xsl:value-of select="c:webpage"/>
        </td>
        <td>
          <xsl:value-of select="c:logo"/>
          <xsl:value-of select="c:ourlogo"/>
        </td>
        <td>
          <xsl:value-of select="c:telephones/c:telephone"/>
          <xsl:value-of select="c:telephone"/>
        </td>
      </tr>
    </xsl:template>
</xsl:stylesheet>
