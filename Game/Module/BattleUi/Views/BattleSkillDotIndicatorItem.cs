using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC7 RID: 24519
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleSkillDotIndicatorItem : UiPanelBase
	{
		// Token: 0x0603DA7A RID: 252538 RVA: 0x00FB556F File Offset: 0x00FB376F
		private string GetResourceId()
		{
			return "UiItem_LuhesSkillPoint";
		}

		// Token: 0x0603DA7B RID: 252539 RVA: 0x00FB5576 File Offset: 0x00FB3776
		public BattleSkillDotIndicatorItem(UUIItem parentItem)
		{
			base.CreateByResourceIdAsync(this.GetResourceId(), parentItem, false).Forget();
		}

		// Token: 0x0603DA7C RID: 252540 RVA: 0x00FB55A8 File Offset: 0x00FB37A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DA7D RID: 252541 RVA: 0x00FB5634 File Offset: 0x00FB3834
		protected override UniTask OnBeforeStartAsync()
		{
			BattleSkillDotIndicatorItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleSkillDotIndicatorItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DA7E RID: 252542 RVA: 0x00FB5677 File Offset: 0x00FB3877
		protected override void OnStart()
		{
			this.IsEnable = true;
			this.SetIconPath(this.IconPath, true);
		}

		// Token: 0x17009A6C RID: 39532
		// (get) Token: 0x0603DA7F RID: 252543 RVA: 0x00FB568D File Offset: 0x00FB388D
		public bool IsComponentActive
		{
			get
			{
				return this.IsActive;
			}
		}

		// Token: 0x0603DA80 RID: 252544 RVA: 0x00FB5695 File Offset: 0x00FB3895
		public void SetComponentActive(bool bShow)
		{
			if (this.IsActive != bShow)
			{
				base.SetUiActive(bShow);
			}
			this.IsActive = bShow;
		}

		// Token: 0x0603DA81 RID: 252545 RVA: 0x00FB56B0 File Offset: 0x00FB38B0
		public void SetCount(int num, bool force = false)
		{
			if (this.CurrentCount == num && !force)
			{
				return;
			}
			this.CurrentCount = num;
			if (!base.GetActive() && !force)
			{
				return;
			}
			for (int i = 0; i < this.DotViews.Count; i++)
			{
				this.DotViews[i].SetDotState(i < num, force);
			}
		}

		// Token: 0x0603DA82 RID: 252546 RVA: 0x00FB570C File Offset: 0x00FB390C
		public void SetIconPath(string iconPath, bool force = false)
		{
			if (this.IconPath == iconPath && !force)
			{
				return;
			}
			this.IconPath = iconPath;
			if (!this.IsEnable)
			{
				return;
			}
			if (this.LoadHandleId != 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandleId);
				this.LoadHandleId = 0;
			}
			if (StringUtils.IsEmpty(this.IconPath))
			{
				using (List<SkillButtonDotIndicator>.Enumerator enumerator = this.DotViews.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SkillButtonDotIndicator skillButtonDotIndicator = enumerator.Current;
						skillButtonDotIndicator.SetIconResource(null);
					}
					return;
				}
			}
			this.LoadHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(this.IconPath, delegate([Nullable(2)] UTexture textureData, string _)
			{
				if (!this.IsEnable)
				{
					return;
				}
				if (this.IconPath != iconPath)
				{
					return;
				}
				foreach (SkillButtonDotIndicator skillButtonDotIndicator2 in this.DotViews)
				{
					skillButtonDotIndicator2.SetIconResource(textureData);
				}
			}, 100, "js_undefined");
		}

		// Token: 0x0603DA83 RID: 252547 RVA: 0x00FB57F4 File Offset: 0x00FB39F4
		protected override void OnBeforeDestroy()
		{
			this.IsEnable = false;
			this.DotViews.Clear();
			if (this.LoadHandleId != 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadHandleId);
				this.LoadHandleId = 0;
			}
		}

		// Token: 0x040229B4 RID: 141748
		private readonly List<SkillButtonDotIndicator> DotViews = new List<SkillButtonDotIndicator>();

		// Token: 0x040229B5 RID: 141749
		private string IconPath = "";

		// Token: 0x040229B6 RID: 141750
		private int LoadHandleId;

		// Token: 0x040229B7 RID: 141751
		private bool IsEnable;

		// Token: 0x040229B8 RID: 141752
		private bool IsActive;

		// Token: 0x040229B9 RID: 141753
		private int CurrentCount;

		// Token: 0x0200C033 RID: 49203
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B2AC RID: 242348
			Dot1,
			// Token: 0x0403B2AD RID: 242349
			Dot2,
			// Token: 0x0403B2AE RID: 242350
			Dot3
		}
	}
}
