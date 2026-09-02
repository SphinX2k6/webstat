using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005391 RID: 21393
	[NullableContext(1)]
	[Nullable(0)]
	public class QteSpineInfoProxy
	{
		// Token: 0x060368DF RID: 223455 RVA: 0x00DCA590 File Offset: 0x00DC8790
		private static List<SpineDataProxy> CreateSpineDataList([Nullable(new byte[]
		{
			2,
			1
		})] TArray<FSpineData> config)
		{
			List<SpineDataProxy> list = new List<SpineDataProxy>();
			if (config == null)
			{
				return list;
			}
			for (int i = 0; i < config.Num(); i++)
			{
				FSpineData fspineData = config.Get(i);
				list.Add(new SpineDataProxy
				{
					Name = fspineData.Name,
					NeedLoop = new bool?(fspineData.NeedLoop)
				});
			}
			return list;
		}

		// Token: 0x060368E0 RID: 223456 RVA: 0x00DCA5EC File Offset: 0x00DC87EC
		private static List<QteProgressSpineSegmentProxy> CreateProgressSpineSegmentList([Nullable(new byte[]
		{
			2,
			1
		})] TArray<FQteProgressSpineSegment> config)
		{
			List<QteProgressSpineSegmentProxy> list = new List<QteProgressSpineSegmentProxy>();
			if (config == null)
			{
				return list;
			}
			for (int i = 0; i < config.Num(); i++)
			{
				FQteProgressSpineSegment fqteProgressSpineSegment = config.Get(i);
				QteProgressSpineSegmentProxy qteProgressSpineSegmentProxy = new QteProgressSpineSegmentProxy();
				qteProgressSpineSegmentProxy.Spines = QteSpineInfoProxy.CreateSpineDataList(fqteProgressSpineSegment.Spines);
				if (qteProgressSpineSegmentProxy.Spines.Count != 0)
				{
					qteProgressSpineSegmentProxy.QteStartProgress = Singleton<MathUtils>.Instance.Clamp(fqteProgressSpineSegment.QteStartPercent * 0.01f, 0f, 1f);
					qteProgressSpineSegmentProxy.QteEndProgress = Singleton<MathUtils>.Instance.Clamp(fqteProgressSpineSegment.QteEndPercent * 0.01f, 0f, 1f);
					qteProgressSpineSegmentProxy.SpineStartProgress = Singleton<MathUtils>.Instance.Clamp(fqteProgressSpineSegment.SpineStartPercent * 0.01f, 0f, 1f);
					qteProgressSpineSegmentProxy.SpineEndProgress = Singleton<MathUtils>.Instance.Clamp(fqteProgressSpineSegment.SpineEndPercent * 0.01f, 0f, 1f);
					qteProgressSpineSegmentProxy.BlendInTime = Math.Max(fqteProgressSpineSegment.BlendInTime, 0f);
					qteProgressSpineSegmentProxy.BlendOutTime = Math.Max(fqteProgressSpineSegment.BlendOutTime, 0f);
					list.Add(qteProgressSpineSegmentProxy);
				}
			}
			return list;
		}

		// Token: 0x060368E1 RID: 223457 RVA: 0x00DCA718 File Offset: 0x00DC8918
		[NullableContext(2)]
		public unsafe static QteSpineInfoProxy CreateQteSpineInfo(FQteSpineInfo config)
		{
			if (config == null)
			{
				return null;
			}
			bool flag = false;
			QteSpineInfoProxy qteSpineInfoProxy = new QteSpineInfoProxy();
			qteSpineInfoProxy.StartLoopSpines = QteSpineInfoProxy.CreateSpineDataList(config.StartLoopSpines);
			if (qteSpineInfoProxy.StartLoopSpines.Count > 0)
			{
				flag = true;
			}
			qteSpineInfoProxy.ProgressSpine = QteSpineInfoProxy.CreateSpineDataList(config.ProgressSpine);
			if (qteSpineInfoProxy.ProgressSpine.Count > 0)
			{
				flag = true;
			}
			qteSpineInfoProxy.ProgressSpineSegments = QteSpineInfoProxy.CreateProgressSpineSegmentList(config.ProgressSpineSegments);
			if (qteSpineInfoProxy.ProgressSpineSegments.Count > 0)
			{
				flag = true;
			}
			else if (qteSpineInfoProxy.ProgressSpine.Count > 0)
			{
				QteSpineInfoProxy qteSpineInfoProxy2 = qteSpineInfoProxy;
				int num = 1;
				List<QteProgressSpineSegmentProxy> list = new List<QteProgressSpineSegmentProxy>(num);
				CollectionsMarshal.SetCount<QteProgressSpineSegmentProxy>(list, num);
				Span<QteProgressSpineSegmentProxy> span = CollectionsMarshal.AsSpan<QteProgressSpineSegmentProxy>(list);
				int index = 0;
				*span[index] = QteProgressSpineSegmentProxy.CreateLegacyProgressSegment(qteSpineInfoProxy.ProgressSpine);
				qteSpineInfoProxy2.ProgressSpineSegments = list;
			}
			qteSpineInfoProxy.EndSpine = QteSpineInfoProxy.CreateSpineDataList(config.EndSpine);
			if (qteSpineInfoProxy.EndSpine.Count > 0)
			{
				flag = true;
			}
			qteSpineInfoProxy.SuccessSpine = QteSpineInfoProxy.CreateSpineDataList(config.SuccessSpine);
			if (qteSpineInfoProxy.SuccessSpine.Count > 0)
			{
				flag = true;
			}
			qteSpineInfoProxy.FailSpine = QteSpineInfoProxy.CreateSpineDataList(config.FailSpine);
			if (qteSpineInfoProxy.FailSpine.Count > 0)
			{
				flag = true;
			}
			qteSpineInfoProxy.WaitEndSpineFinish = config.WaitEndSpineFinish;
			qteSpineInfoProxy.NiagaraParamNames = new List<string>();
			for (int i = 0; i < config.NiagaraParamNames.Num(); i++)
			{
				string item = config.NiagaraParamNames.Get(i);
				qteSpineInfoProxy.NiagaraParamNames.Add(item);
				flag = true;
			}
			if (flag)
			{
				return qteSpineInfoProxy;
			}
			return null;
		}

		// Token: 0x060368E2 RID: 223458 RVA: 0x00DCA898 File Offset: 0x00DC8A98
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> GetProgressSpines()
		{
			List<SpineDataProxy> list = new List<SpineDataProxy>();
			if (this.ProgressSpine != null)
			{
				list.AddRange(this.ProgressSpine);
			}
			if (this.ProgressSpineSegments != null)
			{
				foreach (QteProgressSpineSegmentProxy qteProgressSpineSegmentProxy in this.ProgressSpineSegments)
				{
					list.AddRange(qteProgressSpineSegmentProxy.Spines);
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return list;
		}

		// Token: 0x060368E3 RID: 223459 RVA: 0x00DCA920 File Offset: 0x00DC8B20
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> GetSuccessResultSpine()
		{
			if (this.SuccessSpine != null && this.SuccessSpine.Count > 0)
			{
				return this.SuccessSpine;
			}
			if (this.EndSpine != null && this.EndSpine.Count > 0)
			{
				return this.EndSpine;
			}
			return null;
		}

		// Token: 0x060368E4 RID: 223460 RVA: 0x00DCA95D File Offset: 0x00DC8B5D
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> GetFailResultSpine()
		{
			if (this.FailSpine != null && this.FailSpine.Count > 0)
			{
				return this.FailSpine;
			}
			if (this.EndSpine != null && this.EndSpine.Count > 0)
			{
				return this.EndSpine;
			}
			return null;
		}

		// Token: 0x0401F6D6 RID: 128726
		private const float PERCENT = 0.01f;

		// Token: 0x0401F6D7 RID: 128727
		private const float BLEND_OUT_TIME = 0.5f;

		// Token: 0x0401F6D8 RID: 128728
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> EndSpine;

		// Token: 0x0401F6D9 RID: 128729
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> FailSpine;

		// Token: 0x0401F6DA RID: 128730
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> ProgressSpine;

		// Token: 0x0401F6DB RID: 128731
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<QteProgressSpineSegmentProxy> ProgressSpineSegments;

		// Token: 0x0401F6DC RID: 128732
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> StartLoopSpines;

		// Token: 0x0401F6DD RID: 128733
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SpineDataProxy> SuccessSpine;

		// Token: 0x0401F6DE RID: 128734
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> NiagaraParamNames;

		// Token: 0x0401F6DF RID: 128735
		public bool WaitEndSpineFinish;
	}
}
