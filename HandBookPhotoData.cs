using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001E5A RID: 7770
public class HandBookPhotoData
{
	// Token: 0x04006ED5 RID: 28373
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> TextureList;

	// Token: 0x04006ED6 RID: 28374
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> TypeText;

	// Token: 0x04006ED7 RID: 28375
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> NameText;

	// Token: 0x04006ED8 RID: 28376
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> DescrtptionText;

	// Token: 0x04006ED9 RID: 28377
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> DateText;

	// Token: 0x04006EDA RID: 28378
	public int Index;

	// Token: 0x04006EDB RID: 28379
	public EHandBookTabType HandBookType;

	// Token: 0x04006EDC RID: 28380
	[Nullable(2)]
	public int[] ConfigId;
}
