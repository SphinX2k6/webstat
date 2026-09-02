using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Google.Protobuf;

// Token: 0x0200186A RID: 6250
public class StaticHandler : IHandler
{
	// Token: 0x17000E8B RID: 3723
	// (get) Token: 0x0600B30D RID: 45837 RVA: 0x002FCB03 File Offset: 0x002FAD03
	public EHandlerType Type
	{
		get
		{
			return EHandlerType.Static;
		}
	}

	// Token: 0x17000E8C RID: 3724
	// (get) Token: 0x0600B30E RID: 45838 RVA: 0x002FCB06 File Offset: 0x002FAD06
	// (set) Token: 0x0600B30F RID: 45839 RVA: 0x002FCB0E File Offset: 0x002FAD0E
	public bool? IsSync { get; set; }

	// Token: 0x17000E8D RID: 3725
	// (get) Token: 0x0600B310 RID: 45840 RVA: 0x002FCB17 File Offset: 0x002FAD17
	// (set) Token: 0x0600B311 RID: 45841 RVA: 0x002FCB1F File Offset: 0x002FAD1F
	public bool? IsCache { get; set; }

	// Token: 0x040054BE RID: 21694
	[Nullable(new byte[]
	{
		2,
		2,
		1,
		2
	})]
	public Func<Entity, IMessage, CombatCommon, bool> Preprocessor;

	// Token: 0x040054BF RID: 21695
	[Nullable(new byte[]
	{
		2,
		2,
		1,
		2
	})]
	public Action<Entity, IMessage, CombatCommon> Listener;
}
