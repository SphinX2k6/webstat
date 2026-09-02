using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002318 RID: 8984
public class MotorcycleMusicDetailView : UiViewBase
{
	// Token: 0x0601114E RID: 69966 RVA: 0x004B0F3A File Offset: 0x004AF13A
	[NullableContext(1)]
	public MotorcycleMusicDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601114F RID: 69967 RVA: 0x004B0F44 File Offset: 0x004AF144
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickMaskBtn))
		};
	}

	// Token: 0x06011150 RID: 69968 RVA: 0x004B0FF0 File Offset: 0x004AF1F0
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleMusicDetailView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleMusicDetailView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011151 RID: 69969 RVA: 0x004B1033 File Offset: 0x004AF233
	private void OnClickMaskBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x02008620 RID: 34336
	private class EComponents
	{
		// Token: 0x0402D5CF RID: 185807
		public const int BtnMask = 0;

		// Token: 0x0402D5D0 RID: 185808
		public const int TexAlbum = 1;

		// Token: 0x0402D5D1 RID: 185809
		public const int TxtAlbumName = 2;

		// Token: 0x0402D5D2 RID: 185810
		public const int TxtMusicName = 3;

		// Token: 0x0402D5D3 RID: 185811
		public const int TxtDesc = 4;
	}
}
