using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065F4 RID: 26100
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballMainButtonConfig : IPinballMainButtonConfig
	{
		// Token: 0x17009F2E RID: 40750
		// (get) Token: 0x06041339 RID: 267065 RVA: 0x010B9DE3 File Offset: 0x010B7FE3
		// (set) Token: 0x0604133A RID: 267066 RVA: 0x010B9DEB File Offset: 0x010B7FEB
		public EPinballMainButtonFunctionType Type { get; set; }

		// Token: 0x17009F2F RID: 40751
		// (get) Token: 0x0604133B RID: 267067 RVA: 0x010B9DF4 File Offset: 0x010B7FF4
		// (set) Token: 0x0604133C RID: 267068 RVA: 0x010B9DFC File Offset: 0x010B7FFC
		public int UiRegisterId { get; set; }

		// Token: 0x17009F30 RID: 40752
		// (get) Token: 0x0604133D RID: 267069 RVA: 0x010B9E05 File Offset: 0x010B8005
		// (set) Token: 0x0604133E RID: 267070 RVA: 0x010B9E0D File Offset: 0x010B800D
		public int? FunctionId { get; set; }

		// Token: 0x17009F31 RID: 40753
		// (get) Token: 0x0604133F RID: 267071 RVA: 0x010B9E16 File Offset: 0x010B8016
		// (set) Token: 0x06041340 RID: 267072 RVA: 0x010B9E1E File Offset: 0x010B801E
		public ERedDotName? RedDotName { get; set; }

		// Token: 0x17009F32 RID: 40754
		// (get) Token: 0x06041341 RID: 267073 RVA: 0x010B9E27 File Offset: 0x010B8027
		// (set) Token: 0x06041342 RID: 267074 RVA: 0x010B9E2F File Offset: 0x010B802F
		public Func<bool> ShowRedDot { get; set; }

		// Token: 0x17009F33 RID: 40755
		// (get) Token: 0x06041343 RID: 267075 RVA: 0x010B9E38 File Offset: 0x010B8038
		// (set) Token: 0x06041344 RID: 267076 RVA: 0x010B9E40 File Offset: 0x010B8040
		public Action<UUIText> SetTextCallback { get; set; }

		// Token: 0x17009F34 RID: 40756
		// (get) Token: 0x06041345 RID: 267077 RVA: 0x010B9E49 File Offset: 0x010B8049
		// (set) Token: 0x06041346 RID: 267078 RVA: 0x010B9E51 File Offset: 0x010B8051
		public Action OnClickCallback { get; set; }

		// Token: 0x17009F35 RID: 40757
		// (get) Token: 0x06041347 RID: 267079 RVA: 0x010B9E5A File Offset: 0x010B805A
		// (set) Token: 0x06041348 RID: 267080 RVA: 0x010B9E62 File Offset: 0x010B8062
		public Func<bool> ShowCallback { get; set; }
	}
}
