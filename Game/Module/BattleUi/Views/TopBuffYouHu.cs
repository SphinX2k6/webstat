using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200611F RID: 24863
	public class TopBuffYouHu : TopBuffContainer
	{
		// Token: 0x0603ECE3 RID: 257251 RVA: 0x01015668 File Offset: 0x01013868
		protected override UniTask OnInitAsync()
		{
			TopBuffYouHu.<OnInitAsync>d__3 <OnInitAsync>d__;
			<OnInitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnInitAsync>d__.<>4__this = this;
			<OnInitAsync>d__.<>1__state = -1;
			<OnInitAsync>d__.<>t__builder.Start<TopBuffYouHu.<OnInitAsync>d__3>(ref <OnInitAsync>d__);
			return <OnInitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ECE4 RID: 257252 RVA: 0x010156AC File Offset: 0x010138AC
		public override void SetVisible(bool visible)
		{
			foreach (TopBuffItemYouHu topBuffItemYouHu in this.ItemList)
			{
				topBuffItemYouHu.SetVisible(0, visible);
			}
		}

		// Token: 0x0603ECE5 RID: 257253 RVA: 0x01015700 File Offset: 0x01013900
		private void AddEvents()
		{
			foreach (int tagId in TopBuffYouHu.TagIds)
			{
				base.ListenForTagCountChanged(tagId, new BaseTagComponent.TTagChangedCallback(this.OnTagCountChange));
			}
		}

		// Token: 0x0603ECE6 RID: 257254 RVA: 0x01015738 File Offset: 0x01013938
		private void RemoveEvents()
		{
		}

		// Token: 0x0603ECE7 RID: 257255 RVA: 0x0101573A File Offset: 0x0101393A
		private void OnTagCountChange(int count, int tagId, int exactTagId, int oldCount)
		{
			this.RefreshItemList();
		}

		// Token: 0x0603ECE8 RID: 257256 RVA: 0x01015744 File Offset: 0x01013944
		private void RefreshItemList()
		{
			BattleUiRoleData roleData = this.RoleData;
			BaseTagComponent baseTagComponent = (roleData != null) ? roleData.GameplayTagComponent : null;
			if (baseTagComponent == null)
			{
				foreach (TopBuffItemYouHu topBuffItemYouHu in this.ItemList)
				{
					topBuffItemYouHu.SetVisible(1, false);
				}
				return;
			}
			int num = 0;
			int count = this.ItemList.Count;
			foreach (int tagId in TopBuffYouHu.TagIds)
			{
				int tagCount = baseTagComponent.GetTagCount(tagId);
				for (int j = 0; j < tagCount; j++)
				{
					this.ItemList[num].RefreshByTag(tagId);
					this.ItemList[num].SetVisible(1, true);
					num++;
					if (num >= count)
					{
						return;
					}
				}
			}
			for (int k = num; k < count; k++)
			{
				this.ItemList[k].SetVisible(1, false);
			}
		}

		// Token: 0x0603ECE9 RID: 257257 RVA: 0x0101584C File Offset: 0x01013A4C
		protected override void OnDestroy()
		{
			this.RemoveEvents();
			foreach (TopBuffItemYouHu topBuffItemYouHu in this.ItemList)
			{
				topBuffItemYouHu.Destroy(null);
			}
		}

		// Token: 0x0402339B RID: 144283
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly int[] TagIds = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.如意"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.鼎"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.编钟"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.面具"]
		};

		// Token: 0x0402339C RID: 144284
		[Nullable(1)]
		private readonly List<TopBuffItemYouHu> ItemList = new List<TopBuffItemYouHu>();

		// Token: 0x0200C2A8 RID: 49832
		private enum EItemVisible
		{
			// Token: 0x0403C037 RID: 245815
			Default,
			// Token: 0x0403C038 RID: 245816
			Tag
		}
	}
}
