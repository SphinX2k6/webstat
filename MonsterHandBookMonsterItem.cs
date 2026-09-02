using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02001E9B RID: 7835
internal class MonsterHandBookMonsterItem : LoopScrollMediumItemGrid<int>
{
	// Token: 0x0600E798 RID: 59288 RVA: 0x003E88FC File Offset: 0x003E6AFC
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E799 RID: 59289 RVA: 0x003E891A File Offset: 0x003E6B1A
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E79A RID: 59290 RVA: 0x003E8938 File Offset: 0x003E6B38
	protected override void OnRefresh(int data, bool isSelected, int gridIndex)
	{
		this.HandBookId = data;
		this.SetSelected(isSelected, false);
		MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(this.HandBookId);
		if (monsterInfoConfig == null)
		{
			return;
		}
		MonsterHandBook? monsterHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigById(this.HandBookId);
		if (monsterHandBookConfigById != null && monsterHandBookConfigById.GetValueOrDefault().DefaultUnlock)
		{
			this.IsLock = false;
			PhantomMediumItemGrid parameters = new PhantomMediumItemGrid
			{
				Data = this.HandBookId,
				MonsterId = new int?(monsterInfoConfig.Value.Id),
				BottomTextId = monsterInfoConfig.Value.Name
			};
			base.Apply<PhantomMediumItemGrid>(parameters);
			return;
		}
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Monster, this.HandBookId);
		bool flag = handBookInfo == null || !handBookInfo.IsRead;
		this.IsLock = (handBookInfo == null);
		PhantomMediumItemGrid parameters2 = new PhantomMediumItemGrid
		{
			Data = this.HandBookId,
			MonsterId = (this.IsLock ? null : new int?(monsterInfoConfig.Value.Id)),
			IsNewVisible = new bool?(!this.IsLock && flag),
			IsPhantomLock = new bool?(this.IsLock),
			BottomTextId = (this.IsLock ? "Text_UnDiscovered_Text" : monsterInfoConfig.Value.Name)
		};
		base.Apply<PhantomMediumItemGrid>(parameters2);
	}

	// Token: 0x0600E79B RID: 59291 RVA: 0x003E8ABF File Offset: 0x003E6CBF
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, true);
		if (fireEvent)
		{
			this.OnExtendToggleStateChanged(EToggleState.ETT_Checked);
		}
	}

	// Token: 0x0600E79C RID: 59292 RVA: 0x003E8AD3 File Offset: 0x003E6CD3
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0600E79D RID: 59293 RVA: 0x003E8ADD File Offset: 0x003E6CDD
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<UUIExtendToggle, int, bool> onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			onClickCallBack(this.GetItemGridExtendToggle(), this.HandBookId, this.IsLock);
		}
	}

	// Token: 0x0600E79E RID: 59294 RVA: 0x003E8B05 File Offset: 0x003E6D05
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Monster || id != this.HandBookId)
		{
			return;
		}
		base.SetNewVisible(new bool?(false));
	}

	// Token: 0x04006FA2 RID: 28578
	public int HandBookId;

	// Token: 0x04006FA3 RID: 28579
	private bool IsLock = true;

	// Token: 0x04006FA4 RID: 28580
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int, bool> OnClickCallBack;
}
