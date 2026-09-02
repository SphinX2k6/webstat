using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002595 RID: 9621
public class PhonographNewMusicItem : GridProxyAbstract<int>
{
	// Token: 0x06012BE5 RID: 76773 RVA: 0x0052BC01 File Offset: 0x00529E01
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06012BE6 RID: 76774 RVA: 0x0052BC24 File Offset: 0x00529E24
	public override void Refresh(int musicId, bool isSelected, int gridIndex)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(musicId) : null;
		if (phonographMusic == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), phonographMusic.Value.Title, Array.Empty<object>());
	}

	// Token: 0x020088DE RID: 35038
	private static class EPhonographNewMusicItemDefine
	{
		// Token: 0x0402E35E RID: 189278
		public const int TxtName = 0;
	}
}
