using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F6C RID: 24428
	public class BattleUiEnvironmentKeyData
	{
		// Token: 0x0603D537 RID: 251191 RVA: 0x00F98DEF File Offset: 0x00F96FEF
		public EEnvironmentKey GetCurEnvironmentalKey()
		{
			return this.EnvironmentKey;
		}

		// Token: 0x0603D538 RID: 251192 RVA: 0x00F98DF7 File Offset: 0x00F96FF7
		[NullableContext(2)]
		public string GetCurKeyText()
		{
			return BattleUiEnvironmentKeyData.KeyTexts[(int)this.EnvironmentKey];
		}

		// Token: 0x0603D539 RID: 251193 RVA: 0x00F98E0C File Offset: 0x00F9700C
		public void Init()
		{
			this.EnvironmentKey = EEnvironmentKey.None;
			this.KeyVisibleList.Clear();
			this.KeyVisibleList.Add(true);
			for (int i = 1; i < 10; i++)
			{
				this.KeyVisibleList.Add(false);
			}
		}

		// Token: 0x0603D53A RID: 251194 RVA: 0x00F98E50 File Offset: 0x00F97050
		public void SetEnvironmentKeyVisible(EEnvironmentKey key, bool visible)
		{
			if (this.KeyVisibleList[(int)key] == visible)
			{
				return;
			}
			this.KeyVisibleList[(int)key] = visible;
			if (visible)
			{
				if (this.EnvironmentKey < key)
				{
					this.EnvironmentKey = key;
					this.DispatchKeyChangedEvent();
				}
				return;
			}
			if (this.EnvironmentKey > key)
			{
				return;
			}
			for (int i = key - EEnvironmentKey.SilentArea; i >= 0; i--)
			{
				if (this.KeyVisibleList[i])
				{
					this.EnvironmentKey = (EEnvironmentKey)i;
					this.DispatchKeyChangedEvent();
					return;
				}
			}
		}

		// Token: 0x0603D53B RID: 251195 RVA: 0x00F98EC8 File Offset: 0x00F970C8
		private void DispatchKeyChangedEvent()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiEnvironmentKeyChanged);
		}

		// Token: 0x0603D53C RID: 251196 RVA: 0x00F98EDC File Offset: 0x00F970DC
		public void OnLeaveLevel()
		{
			this.EnvironmentKey = EEnvironmentKey.None;
			for (int i = 1; i < 10; i++)
			{
				this.KeyVisibleList[i] = false;
			}
		}

		// Token: 0x0603D53D RID: 251197 RVA: 0x00F98F0A File Offset: 0x00F9710A
		public void Clear()
		{
		}

		// Token: 0x040226EC RID: 141036
		private EEnvironmentKey EnvironmentKey;

		// Token: 0x040226ED RID: 141037
		[Nullable(new byte[]
		{
			1,
			2
		})]
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyList<string> KeyTexts = new <>z__ReadOnlyArray<string>(new string[]
		{
			null,
			"HotKeyText_SilentAreaTips_Name",
			"HotKeyText_EnvironmentBuffTips_Name",
			"HotKeyText_SilentAreaTips_Name",
			"HotKeyText_RogueInfoTips_Name",
			"HotKeyText_VisionLevelTips_Name",
			"HotKeyText_TowerTokenTips_Name",
			"HotKeyText_RogueInfoTips_Name",
			"HotKeyText_MoraleTokenTips_Name",
			"HotKeyText_MoraleAreaSum_Name"
		});

		// Token: 0x040226EE RID: 141038
		[Nullable(1)]
		private readonly List<bool> KeyVisibleList = new List<bool>();
	}
}
