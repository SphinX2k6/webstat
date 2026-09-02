using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005390 RID: 21392
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SequenceQteGroup : SequenceQteHandleBase<CommonQteGroupContext>
	{
		// Token: 0x060368D7 RID: 223447 RVA: 0x00DCA27C File Offset: 0x00DC847C
		public SequenceQteGroup(SequenceQteManager qteManager, CommonQteGroupContext context) : base(qteManager, context)
		{
			if (this.Context.ContextMap != null)
			{
				foreach (KeyValuePair<int, CommonQteContextBase> keyValuePair in this.Context.ContextMap)
				{
					CommonQteContextBase value = keyValuePair.Value;
					value.SuccessCallback = new TCommonQteCallback(this.OnSubQteSucceed);
					value.FailCallback = new TCommonQteCallback(this.OnSubQteFailed);
				}
			}
		}

		// Token: 0x060368D8 RID: 223448 RVA: 0x00DCA32C File Offset: 0x00DC852C
		public override void OnBegin()
		{
			base.OnBegin();
			this.MarkSequenceQtePending = true;
		}

		// Token: 0x060368D9 RID: 223449 RVA: 0x00DCA33B File Offset: 0x00DC853B
		public override void OnFinish()
		{
			base.OnFinish();
			this.CacheIntervalCheckProgressMap.Clear();
		}

		// Token: 0x060368DA RID: 223450 RVA: 0x00DCA350 File Offset: 0x00DC8550
		protected override void OnReceiveTick(float delta)
		{
			if (this.Context.ContextMap == null || this.Context.MainQteContext == null || this.Context.ContextMap.Count == 0)
			{
				return;
			}
			this.PauseTimeCheck += (int)delta;
			bool flag = this.PauseTimeCheck >= 50;
			if (flag)
			{
				this.PauseTimeCheck = 0;
			}
			double num = 0.0;
			foreach (KeyValuePair<int, CommonQteContextBase> keyValuePair in this.Context.ContextMap)
			{
				CommonQteContextBase value = keyValuePair.Value;
				if (value.Type.GetValueOrDefault() == ECommonQteContextType.SingleButtonContinuousClick)
				{
					if (flag)
					{
						this.CacheIntervalCheckProgressMap[value.HandleId] = (double)value.GetProgress();
						num += (double)value.GetProgress();
					}
					else
					{
						double num2;
						num += (this.CacheIntervalCheckProgressMap.TryGetValue(value.HandleId, out num2) ? num2 : 0.0);
					}
				}
				else if (value.Type.GetValueOrDefault() == ECommonQteContextType.SingleButtonLongPress)
				{
					num += (double)value.GetProgress();
				}
				else
				{
					num += (double)(value.IsSuccess() ? 100 : 0);
				}
			}
			this.Progress = (float)Singleton<MathUtils>.Instance.Clamp(num / (double)this.Context.ContextMap.Count * 0.009999999776482582, 0.0, 1.0);
		}

		// Token: 0x060368DB RID: 223451 RVA: 0x00DCA4E0 File Offset: 0x00DC86E0
		public void SetSubQteParams([Nullable(new byte[]
		{
			2,
			1
		})] List<MovieSceneSubQteParamsProxy> parameters)
		{
			if (parameters == null)
			{
				return;
			}
			foreach (MovieSceneSubQteParamsProxy movieSceneSubQteParamsProxy in parameters)
			{
				this.SubQteParamsMap[movieSceneSubQteParamsProxy.SubQteId] = movieSceneSubQteParamsProxy;
			}
		}

		// Token: 0x060368DC RID: 223452 RVA: 0x00DCA540 File Offset: 0x00DC8740
		[NullableContext(2)]
		private void OnSubQteSucceed(CommonQteContextBase context)
		{
			this.PlaySubResultSpine(context, true);
		}

		// Token: 0x060368DD RID: 223453 RVA: 0x00DCA54A File Offset: 0x00DC874A
		[NullableContext(2)]
		private void OnSubQteFailed(CommonQteContextBase context)
		{
			this.PlaySubResultSpine(context, false);
		}

		// Token: 0x060368DE RID: 223454 RVA: 0x00DCA554 File Offset: 0x00DC8754
		[NullableContext(2)]
		private void PlaySubResultSpine(CommonQteContextBase context, bool isSuccess)
		{
			if (context == null)
			{
				return;
			}
			MovieSceneSubQteParamsProxy movieSceneSubQteParamsProxy;
			if (!this.SubQteParamsMap.TryGetValue(context.QteId, out movieSceneSubQteParamsProxy))
			{
				return;
			}
			QteSpineInfoProxy spineInfo = movieSceneSubQteParamsProxy.SpineInfo;
			if (spineInfo == null)
			{
				return;
			}
			base.PlayResultSpine(isSuccess, spineInfo);
		}

		// Token: 0x0401F6D2 RID: 128722
		private const int PAUSED_TIME_BUFFER = 50;

		// Token: 0x0401F6D3 RID: 128723
		private readonly Dictionary<int, MovieSceneSubQteParamsProxy> SubQteParamsMap = new Dictionary<int, MovieSceneSubQteParamsProxy>();

		// Token: 0x0401F6D4 RID: 128724
		private int PauseTimeCheck = 50;

		// Token: 0x0401F6D5 RID: 128725
		private readonly Dictionary<int, double> CacheIntervalCheckProgressMap = new Dictionary<int, double>();
	}
}
