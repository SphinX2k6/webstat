using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007011 RID: 28689
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class TouchUiEditController : ControllerBase<TouchUiEditController>
	{
		// Token: 0x06045744 RID: 284484 RVA: 0x0122919C File Offset: 0x0122739C
		protected override bool OnInit()
		{
			this.AddDataFacade(typeof(CommonTouchUiEditDataFacade));
			foreach (ITouchUiEditDataFacade touchUiEditDataFacade in this.DataFacadeMap.Values)
			{
				touchUiEditDataFacade.Init();
			}
			return true;
		}

		// Token: 0x06045745 RID: 284485 RVA: 0x01229204 File Offset: 0x01227404
		protected override bool OnClear()
		{
			foreach (ITouchUiEditDataFacade touchUiEditDataFacade in this.DataFacadeMap.Values)
			{
				touchUiEditDataFacade.Clear();
			}
			this.DataFacadeMap.Clear();
			return true;
		}

		// Token: 0x06045746 RID: 284486 RVA: 0x01229268 File Offset: 0x01227468
		private void AddDataFacade(Type type)
		{
			ITouchUiEditDataFacade touchUiEditDataFacade = Activator.CreateInstance(type) as ITouchUiEditDataFacade;
			if (touchUiEditDataFacade != null)
			{
				this.DataFacadeMap[type.Name] = touchUiEditDataFacade;
			}
		}

		// Token: 0x06045747 RID: 284487 RVA: 0x01229298 File Offset: 0x01227498
		[NullableContext(0)]
		[return: Nullable(2)]
		public T GetDataFacade<T>() where T : ITouchUiEditDataFacade
		{
			ITouchUiEditDataFacade touchUiEditDataFacade;
			if (this.DataFacadeMap.TryGetValue(typeof(T).Name, out touchUiEditDataFacade))
			{
				return (T)((object)touchUiEditDataFacade);
			}
			return default(T);
		}

		// Token: 0x06045748 RID: 284488 RVA: 0x012292D4 File Offset: 0x012274D4
		public void OpenCommonTouchUiEditView(int group)
		{
			CommonTouchUiEditContainer container = new CommonTouchUiEditContainer();
			CommonTouchUiEditDataFacade dataFacade = this.GetDataFacade<CommonTouchUiEditDataFacade>();
			if (dataFacade == null)
			{
				return;
			}
			dataFacade.SetGroup(group);
			TouchUiEditProxy param = new TouchUiEditProxy(container, dataFacade, (UUIItem item, [Nullable(2)] ITouchUiEditData data) => new CommonTouchUiEditItem(item, data));
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonTouchUiEditView, param, null);
		}

		// Token: 0x06045749 RID: 284489 RVA: 0x01229334 File Offset: 0x01227534
		[NullableContext(2)]
		public TouchUiEditProxy CreateProxyForFunction(EFunction functionId)
		{
			if (functionId == EFunction.MotorMobileButtonCustom)
			{
				int group = 2;
				int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.MotorMobileButtonLayout, true, true);
				if (currentValue != null)
				{
					int? num = currentValue;
					int num2 = 0;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						group = 3;
					}
				}
				return this.CreateCommonProxy(group);
			}
			return null;
		}

		// Token: 0x0604574A RID: 284490 RVA: 0x0122938C File Offset: 0x0122758C
		[NullableContext(2)]
		private TouchUiEditProxy CreateCommonProxy(int group)
		{
			CommonTouchUiEditContainer container = new CommonTouchUiEditContainer();
			CommonTouchUiEditDataFacade dataFacade = this.GetDataFacade<CommonTouchUiEditDataFacade>();
			if (dataFacade == null)
			{
				return null;
			}
			dataFacade.SetGroup(group);
			return new TouchUiEditProxy(container, dataFacade, (UUIItem item, [Nullable(2)] ITouchUiEditData data) => new CommonTouchUiEditItem(item, data));
		}

		// Token: 0x04026CFC RID: 158972
		private readonly Dictionary<string, ITouchUiEditDataFacade> DataFacadeMap = new Dictionary<string, ITouchUiEditDataFacade>();
	}
}
