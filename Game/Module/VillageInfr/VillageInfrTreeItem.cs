using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C19 RID: 19481
	[NullableContext(1)]
	[Nullable(0)]
	internal class VillageInfrTreeItem : UiPanelBase
	{
		// Token: 0x06032D0A RID: 208138 RVA: 0x00CBB740 File Offset: 0x00CB9940
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTreeItem))
			};
		}

		// Token: 0x06032D0B RID: 208139 RVA: 0x00CBB886 File Offset: 0x00CB9A86
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x06032D0C RID: 208140 RVA: 0x00CBB8B4 File Offset: 0x00CB9AB4
		public void PlayLevelSequenceByName(string name)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName(name, false, null, false);
		}

		// Token: 0x06032D0D RID: 208141 RVA: 0x00CBB8DD File Offset: 0x00CB9ADD
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "GetL" || sequenceName == "GetR")
			{
				this.NeedPlayFinish = false;
				this.RefreshFinish();
				Action onGetSeqEnd = this.OnGetSeqEnd;
				if (onGetSeqEnd == null)
				{
					return;
				}
				onGetSeqEnd();
			}
		}

		// Token: 0x06032D0E RID: 208142 RVA: 0x00CBB916 File Offset: 0x00CB9B16
		private void OnClickTreeItem(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			Action<int, EVillageInfrSelectType> selectCb = this.SelectCb;
			if (selectCb != null)
			{
				selectCb(this.Id, this.SelectType);
			}
			this.SetSelected(true);
		}

		// Token: 0x06032D0F RID: 208143 RVA: 0x00CBB944 File Offset: 0x00CB9B44
		[NullableContext(2)]
		public void Refresh(int id, EVillageInfrSelectType type, IVillageInfrBuildFinishTipParam param = null)
		{
			this.Id = id;
			this.SelectType = type;
			this.NeedPlayFinish = (param != null && param.SelectType == EVillageInfrSelectType.Tree && param.SelectId == id);
			this.RefreshName();
			this.RefreshFinish();
			this.RefreshLevelUp();
			this.RefreshLock();
		}

		// Token: 0x06032D10 RID: 208144 RVA: 0x00CBB998 File Offset: 0x00CB9B98
		private void RefreshName()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				InfrV2TreeBuild? infrTreeBuild = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.Id);
				base.GetText(7).ShowTextNew(infrTreeBuild.Value.Name);
				base.GetSprite(11).SetUIActive(this.Id == ModelBase<VillageInfrModel>.Instance.GetTraceTreeId());
				return;
			}
			base.GetSprite(11).SetUIActive(false);
		}

		// Token: 0x06032D11 RID: 208145 RVA: 0x00CBBA08 File Offset: 0x00CB9C08
		private bool IsFinish()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(this.Id);
				return treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusComplete;
			}
			int infrMaxLevel = ConfigBase<VillageInfrConfig>.Instance.GetInfrMaxLevel();
			return this.Id >= infrMaxLevel;
		}

		// Token: 0x06032D12 RID: 208146 RVA: 0x00CBBA54 File Offset: 0x00CB9C54
		private void RefreshFinish()
		{
			bool flag = this.IsFinish();
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				base.GetItem(4).SetUIActive(flag);
			}
			else
			{
				base.GetItem(4).SetUIActive(flag);
				UUIItem sprite = base.GetSprite(6);
				bool bUseChangeColor = flag;
				FColor? fcolor = new FColor?(base.GetSprite(6).changeColor);
				sprite.SetChangeColor(bUseChangeColor, fcolor);
			}
			this.RefreshLineVisible();
		}

		// Token: 0x06032D13 RID: 208147 RVA: 0x00CBBAB4 File Offset: 0x00CB9CB4
		private void RefreshLineVisible()
		{
			bool flag = this.IsFinish();
			if (this.NeedPlayFinish)
			{
				flag = !flag;
			}
			bool isSelected = this.IsSelected;
			base.GetTexture(1).SetUIActive(!isSelected && !flag);
			base.GetTexture(2).SetUIActive(!isSelected && flag);
			base.GetTexture(8).SetUIActive(isSelected && !flag);
			base.GetTexture(9).SetUIActive(isSelected && flag);
			base.GetTexture(10).SetUIActive(this.NeedPlayFinish);
		}

		// Token: 0x06032D14 RID: 208148 RVA: 0x00CBBB3D File Offset: 0x00CB9D3D
		private void RefreshLevelUp()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				base.GetSprite(5).SetUIActive(ModelBase<VillageInfrModel>.Instance.GetCanTreeLevelUp(this.Id));
				return;
			}
			base.GetSprite(5).SetUIActive(ModelBase<VillageInfrModel>.Instance.GetCanVillageLevelUp());
		}

		// Token: 0x06032D15 RID: 208149 RVA: 0x00CBBB7B File Offset: 0x00CB9D7B
		private void RefreshLock()
		{
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				base.GetItem(3).SetUIActive(!ModelBase<VillageInfrModel>.Instance.GetTreeIsUnlock(this.Id));
				return;
			}
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x06032D16 RID: 208150 RVA: 0x00CBBBB3 File Offset: 0x00CB9DB3
		public void SetSelectCb(Action<int, EVillageInfrSelectType> cb)
		{
			this.SelectCb = cb;
		}

		// Token: 0x06032D17 RID: 208151 RVA: 0x00CBBBBC File Offset: 0x00CB9DBC
		public void SetOnGetSeqEnd(Action cb)
		{
			this.OnGetSeqEnd = cb;
		}

		// Token: 0x06032D18 RID: 208152 RVA: 0x00CBBBC5 File Offset: 0x00CB9DC5
		public void SetSelected(bool isSelected)
		{
			this.IsSelected = isSelected;
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshLineVisible();
		}

		// Token: 0x0401D93B RID: 121147
		public int Id;

		// Token: 0x0401D93C RID: 121148
		public EVillageInfrSelectType SelectType;

		// Token: 0x0401D93D RID: 121149
		private bool IsSelected;

		// Token: 0x0401D93E RID: 121150
		[Nullable(2)]
		private Action<int, EVillageInfrSelectType> SelectCb;

		// Token: 0x0401D93F RID: 121151
		[Nullable(2)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0401D940 RID: 121152
		[Nullable(2)]
		private Action OnGetSeqEnd;

		// Token: 0x0401D941 RID: 121153
		private bool NeedPlayFinish;
	}
}
