using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x02006619 RID: 26137
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemGridComponentBase : UiPanelBase
	{
		// Token: 0x0604150F RID: 267535 RVA: 0x010C0EA4 File Offset: 0x010BF0A4
		public void Refresh(params object[] args)
		{
			this.OnRefresh(args);
		}

		// Token: 0x06041510 RID: 267536 RVA: 0x010C0EAD File Offset: 0x010BF0AD
		public string GetResourceId()
		{
			return this.OnGetResourceId() ?? "";
		}

		// Token: 0x06041511 RID: 267537 RVA: 0x010C0EC0 File Offset: 0x010BF0C0
		protected virtual void OnRefresh(params object[] args)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SurvivorsRogue;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "没有实现 OnRefresh";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentName", base.GetType().Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06041512 RID: 267538 RVA: 0x010C0F04 File Offset: 0x010BF104
		[NullableContext(2)]
		protected virtual string OnGetResourceId()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SurvivorsRogue;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "没有实现 GetResourceId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentName", base.GetType().Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06041513 RID: 267539 RVA: 0x010C0F46 File Offset: 0x010BF146
		public override void SetActive(bool visibility)
		{
			base.SetUiActive(visibility);
			Action<PinballItemGridComponentBase, bool> onComponentVisibleChanged = this.OnComponentVisibleChanged;
			if (onComponentVisibleChanged == null)
			{
				return;
			}
			onComponentVisibleChanged(this, visibility);
		}

		// Token: 0x040248B6 RID: 149686
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<PinballItemGridComponentBase, bool> OnComponentVisibleChanged;
	}
}
