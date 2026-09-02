using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001210 RID: 4624
[NullableContext(2)]
[Nullable(0)]
internal class DesRightBuffGridItem : GridProxyAbstract<int>
{
	// Token: 0x06007A77 RID: 31351 RVA: 0x001FF2DC File Offset: 0x001FD4DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007A78 RID: 31352 RVA: 0x001FF3E5 File Offset: 0x001FD5E5
	protected override void OnStart()
	{
		if (this.RootItem != null)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}
	}

	// Token: 0x06007A79 RID: 31353 RVA: 0x001FF400 File Offset: 0x001FD600
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.DeTermId = data;
		BabelTowerDeTerm? config = ConfigBabelTowerDeTermById.GetConfig(data, true);
		if (config == null)
		{
			return;
		}
		BabelTowerDeTerm value = config.Value;
		UUIText text = base.GetText(3);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, value.DesText, Array.Empty<object>());
		}
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetText(value.Star.ToString() ?? "", true);
		}
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			base.SetTextureByPath(value.Texture, texture, null, null);
		}
		UUITexture texture2 = base.GetTexture(1);
		if (texture2 != null)
		{
			texture2.SetUIActive(gridIndex % 2 == 0);
		}
	}

	// Token: 0x06007A7A RID: 31354 RVA: 0x001FF4BC File Offset: 0x001FD6BC
	public void PlayStartSequence()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		}
	}

	// Token: 0x06007A7B RID: 31355 RVA: 0x001FF4EC File Offset: 0x001FD6EC
	public void PlayCloseSequence()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Close", false, null);
		}
	}

	// Token: 0x06007A7C RID: 31356 RVA: 0x001FF51B File Offset: 0x001FD71B
	private void OnClickBtn()
	{
		Action<int> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack(this.DeTermId);
	}

	// Token: 0x04003ACB RID: 15051
	public int DeTermId;

	// Token: 0x04003ACC RID: 15052
	public Action<int> OnClickCallBack;

	// Token: 0x04003ACD RID: 15053
	public Action<int, bool> OnBuffStateChange;

	// Token: 0x04003ACE RID: 15054
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007560 RID: 30048
	[NullableContext(0)]
	private class EBuffItemSubComponent
	{
		// Token: 0x04028802 RID: 165890
		public const int BuffItemRoot = 0;

		// Token: 0x04028803 RID: 165891
		public const int TexBg = 1;

		// Token: 0x04028804 RID: 165892
		public const int TexIcon = 2;

		// Token: 0x04028805 RID: 165893
		public const int TxtDesc = 3;

		// Token: 0x04028806 RID: 165894
		public const int TxtNum = 4;
	}
}
