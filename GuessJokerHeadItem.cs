using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200112D RID: 4397
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerHeadItem : UiPanelBase
{
	// Token: 0x06007318 RID: 29464 RVA: 0x001E17C8 File Offset: 0x001DF9C8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUISprite)),
			new ValueTuple<int, Type>(12, typeof(UUITexture)),
			new ValueTuple<int, Type>(13, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickSkillButton))
		};
	}

	// Token: 0x06007319 RID: 29465 RVA: 0x001E1940 File Offset: 0x001DFB40
	protected override void OnStart()
	{
		this.HpLayout = new GenericLayout<GuessJokerHpItem, bool>(base.GetHorizontalLayout(2), new Func<GuessJokerHpItem>(this.CreateHpItem), (AUIBaseActor)base.GetItem(3).GetOwner(), false, true);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		AUIBaseActor auibaseActor = base.GetButton(10).GetOwner() as AUIBaseActor;
		this.SkillButtonSequencePlayer = new LevelSequencePlayer((auibaseActor != null) ? auibaseActor.GetUIItem() : null);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceFinish), false);
		}
		LevelSequencePlayer skillButtonSequencePlayer = this.SkillButtonSequencePlayer;
		if (skillButtonSequencePlayer == null)
		{
			return;
		}
		skillButtonSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceFinish), false);
	}

	// Token: 0x0600731A RID: 29466 RVA: 0x001E1A10 File Offset: 0x001DFC10
	private void OnSequenceFinish(string sequenceName)
	{
		Action action;
		if (this.SequenceFinishCallbackMap.TryGetValue(sequenceName, out action))
		{
			if (action != null)
			{
				action();
			}
			this.SequenceFinishCallbackMap.Remove(sequenceName);
		}
	}

	// Token: 0x0600731B RID: 29467 RVA: 0x001E1A43 File Offset: 0x001DFC43
	public void SetRoleData(GuessJokerRoleData roleData)
	{
		this.RoleData = roleData;
		this.InitView();
	}

	// Token: 0x17000953 RID: 2387
	// (get) Token: 0x0600731C RID: 29468 RVA: 0x001E1A52 File Offset: 0x001DFC52
	public int Hp
	{
		get
		{
			GuessJokerRoleData roleData = this.RoleData;
			if (roleData == null)
			{
				return 0;
			}
			return roleData.GetHp();
		}
	}

	// Token: 0x0600731D RID: 29469 RVA: 0x001E1A68 File Offset: 0x001DFC68
	public void InitView()
	{
		if (this.RoleData == null)
		{
			return;
		}
		int num;
		if (this.RoleData.GetPlayerType() == EGuessJokerPlayerType.Me)
		{
			num = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().Value;
		}
		else
		{
			num = ModelBase<GuessJokerGamePlayModel>.Instance.GetRoleId();
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num);
		if (roleConfig != null)
		{
			base.SetRoleIcon(roleConfig.Value.RoleHeadIconCircle, base.GetTexture(1), num, null, null);
		}
		bool isFinish = ModelBase<GuessJokerGamePlayModel>.Instance.IsFinish;
		this.SetSkillUnlock(isFinish);
		GuessJokerRoleData roleData = this.RoleData;
		int num2 = (roleData != null) ? roleData.GetMaxHp() : 0;
		List<bool> list = new List<bool>(num2);
		for (int i = 0; i < num2; i++)
		{
			list.Add(false);
		}
		GuessJokerRoleData roleData2 = this.RoleData;
		int num3 = (roleData2 != null) ? roleData2.GetHp() : 0;
		for (int j = 0; j < num3; j++)
		{
			list[j] = true;
		}
		this.HpLayout.RefreshByData(list, null, false);
		base.GetItem(5).SetUIActive(false);
	}

	// Token: 0x0600731E RID: 29470 RVA: 0x001E1B7C File Offset: 0x001DFD7C
	[NullableContext(2)]
	public void UpdateHp(Action completeCallback = null)
	{
		string sequenceName = "PlayerHit";
		if (this.IsPlayer)
		{
			sequenceName = "MeHit";
		}
		this.PlayHeadSequence(sequenceName, delegate
		{
			GuessJokerRoleData roleData = this.RoleData;
			int num = (roleData != null) ? roleData.GetMaxHp() : 0;
			List<bool> list = new List<bool>(num);
			for (int i = 0; i < num; i++)
			{
				list.Add(false);
			}
			GuessJokerRoleData roleData2 = this.RoleData;
			int num2 = (roleData2 != null) ? roleData2.GetHp() : 0;
			for (int j = 0; j < num2; j++)
			{
				list[j] = true;
			}
			this.HpLayout.RefreshByData(list, null, false);
			if (num2 <= 0)
			{
				this.PlayHeadSequence("Kill", completeCallback);
				return;
			}
			Action completeCallback2 = completeCallback;
			if (completeCallback2 == null)
			{
				return;
			}
			completeCallback2();
		});
	}

	// Token: 0x0600731F RID: 29471 RVA: 0x001E1BC4 File Offset: 0x001DFDC4
	public void SetSkillUnlock(bool isUnlock)
	{
		this.IsUnlock = isUnlock;
		bool flag = isUnlock || this.IsPlayer;
		if (flag)
		{
			this.UpdateSkill();
		}
		base.GetSprite(11).SetUIActive(!flag);
		base.GetTexture(12).SetUIActive(flag);
		if (flag)
		{
			this.ShowLockSkillTips(false);
		}
	}

	// Token: 0x06007320 RID: 29472 RVA: 0x001E1C18 File Offset: 0x001DFE18
	private void UpdateSkill()
	{
		if (this.RoleData == null)
		{
			return;
		}
		int skillId;
		if (this.RoleData.GetPlayerType() == EGuessJokerPlayerType.Me)
		{
			skillId = 100001;
		}
		else
		{
			skillId = ModelBase<GuessJokerGamePlayModel>.Instance.GetAiSkillId();
		}
		this.SkillId = skillId;
		JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(skillId);
		if (jokerSkill != null)
		{
			UUITextureTransitionComponent textureTransitionComp = base.GetTexture(12).GetOwner().GetComponentByClass(UUITextureTransitionComponent.StaticClass()) as UUITextureTransitionComponent;
			base.SetTextureByPath(jokerSkill.Value.WhiteSkillIconPath, base.GetTexture(12), null, delegate(bool _)
			{
				textureTransitionComp.SetAllStateTexture(this.GetTexture(12).GetTexture());
			});
		}
	}

	// Token: 0x06007321 RID: 29473 RVA: 0x001E1CD4 File Offset: 0x001DFED4
	public void PlayHeadSequence(string sequenceName, [Nullable(2)] Action finishCallback = null)
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}
		if (finishCallback != null)
		{
			this.SequenceFinishCallbackMap[sequenceName] = finishCallback;
		}
	}

	// Token: 0x06007322 RID: 29474 RVA: 0x001E1D10 File Offset: 0x001DFF10
	public void SetSelfRound(bool isSelfRound)
	{
		if (isSelfRound)
		{
			base.GetItem(5).SetUIActive(true);
			this.PlayHeadSequence("Sle", null);
			return;
		}
		this.PlayHeadSequence("Unsle", delegate
		{
			base.GetItem(5).SetUIActive(false);
		});
	}

	// Token: 0x06007323 RID: 29475 RVA: 0x001E1D48 File Offset: 0x001DFF48
	private void PlaySkillButtonSequence(string sequenceName, [Nullable(2)] Action finishCallback = null)
	{
		LevelSequencePlayer skillButtonSequencePlayer = this.SkillButtonSequencePlayer;
		if (skillButtonSequencePlayer != null)
		{
			skillButtonSequencePlayer.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}
		if (finishCallback != null)
		{
			this.SequenceFinishCallbackMap[sequenceName] = finishCallback;
		}
	}

	// Token: 0x06007324 RID: 29476 RVA: 0x001E1D84 File Offset: 0x001DFF84
	private GuessJokerHpItem CreateHpItem()
	{
		return new GuessJokerHpItem();
	}

	// Token: 0x06007325 RID: 29477 RVA: 0x001E1D8B File Offset: 0x001DFF8B
	public void SetDialogueText(string textKey)
	{
		if (!this.IsPlayer)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), textKey, Array.Empty<object>());
	}

	// Token: 0x06007326 RID: 29478 RVA: 0x001E1DB0 File Offset: 0x001DFFB0
	[NullableContext(2)]
	public void SetDialogueItemActive(bool active, Action onComplete = null)
	{
		if (!this.IsPlayer)
		{
			return;
		}
		if (active)
		{
			base.GetItem(8).SetUIActive(true);
			this.PlayHeadSequence("WordShow", onComplete);
			return;
		}
		this.PlayHeadSequence("WordHide", delegate
		{
			this.GetItem(8).SetUIActive(false);
			Action onComplete2 = onComplete;
			if (onComplete2 == null)
			{
				return;
			}
			onComplete2();
		});
	}

	// Token: 0x06007327 RID: 29479 RVA: 0x001E1E14 File Offset: 0x001E0014
	public void ShowLockSkillTips(bool active)
	{
		if (this.IsLockSkillTipsClicked)
		{
			return;
		}
		this.IsLockSkillTipsClicked = true;
		if (active)
		{
			base.GetItem(13).SetUIActive(true);
			this.IsLockSkillTipsClicked = false;
			this.PlaySkillButtonSequence("TipsShow", null);
			return;
		}
		this.IsLockSkillTipsClicked = false;
		this.PlaySkillButtonSequence("TipsHide", delegate
		{
			base.GetItem(13).SetUIActive(false);
		});
	}

	// Token: 0x17000954 RID: 2388
	// (get) Token: 0x06007328 RID: 29480 RVA: 0x001E1E74 File Offset: 0x001E0074
	private bool IsPlayer
	{
		get
		{
			GuessJokerRoleData roleData = this.RoleData;
			return roleData != null && roleData.GetPlayerType() == EGuessJokerPlayerType.Me;
		}
	}

	// Token: 0x06007329 RID: 29481 RVA: 0x001E1E8C File Offset: 0x001E008C
	private void OnClickSkillButton()
	{
		if (!this.IsUnlock && !this.IsPlayer)
		{
			if (!this.IsLockSkillTipsClicked)
			{
				bool active = !base.GetItem(13).bIsUIActive;
				this.ShowLockSkillTips(active);
			}
			return;
		}
		JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(this.SkillId);
		if (jokerSkill != null)
		{
			int helpId = jokerSkill.Value.HelpId;
			if (helpId != 0)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
			}
		}
	}

	// Token: 0x04003791 RID: 14225
	[Nullable(2)]
	public GuessJokerRoleData RoleData;

	// Token: 0x04003792 RID: 14226
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<GuessJokerHpItem, bool> HpLayout;

	// Token: 0x04003793 RID: 14227
	private bool IsUnlock;

	// Token: 0x04003794 RID: 14228
	private int SkillId = -1;

	// Token: 0x04003795 RID: 14229
	private bool IsLockSkillTipsClicked;

	// Token: 0x04003796 RID: 14230
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04003797 RID: 14231
	[Nullable(2)]
	private LevelSequencePlayer SkillButtonSequencePlayer;

	// Token: 0x04003798 RID: 14232
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	private readonly Dictionary<string, Action> SequenceFinishCallbackMap = new Dictionary<string, Action>();

	// Token: 0x020074B7 RID: 29879
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040284E8 RID: 165096
		public const int Button = 0;

		// Token: 0x040284E9 RID: 165097
		public const int RoleTexture = 1;

		// Token: 0x040284EA RID: 165098
		public const int HpHorizontalLayout = 2;

		// Token: 0x040284EB RID: 165099
		public const int HpItem = 3;

		// Token: 0x040284EC RID: 165100
		public const int HeadBgItem = 4;

		// Token: 0x040284ED RID: 165101
		public const int SelectItem = 5;

		// Token: 0x040284EE RID: 165102
		public const int TimePanel = 6;

		// Token: 0x040284EF RID: 165103
		public const int TimeProgressSprite = 7;

		// Token: 0x040284F0 RID: 165104
		public const int DialoguePanel = 8;

		// Token: 0x040284F1 RID: 165105
		public const int DialogueText = 9;

		// Token: 0x040284F2 RID: 165106
		public const int SkillButton = 10;

		// Token: 0x040284F3 RID: 165107
		public const int LockSprite = 11;

		// Token: 0x040284F4 RID: 165108
		public const int SkillTexture = 12;

		// Token: 0x040284F5 RID: 165109
		public const int LockSkillTipsItem = 13;
	}
}
