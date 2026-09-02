using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056DD RID: 22237
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MusicalInstrumentModel : ModelBase<MusicalInstrumentModel>
	{
		// Token: 0x170090D3 RID: 37075
		// (get) Token: 0x06038973 RID: 231795 RVA: 0x00E55ED0 File Offset: 0x00E540D0
		public bool IsAnyInputRestricted
		{
			get
			{
				using (Dictionary<EInstrumentType, MusicalInstrumentSubModel>.ValueCollection.Enumerator enumerator = this.SubModels.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsInputRestricted)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x06038974 RID: 231796 RVA: 0x00E55F30 File Offset: 0x00E54130
		protected override bool OnInit()
		{
			this.Register(new GuqinSubModel());
			return true;
		}

		// Token: 0x06038975 RID: 231797 RVA: 0x00E55F3E File Offset: 0x00E5413E
		private void Register(MusicalInstrumentSubModel subModel)
		{
			subModel.OnRegister();
			this.SubModels[subModel.GetType()] = subModel;
		}

		// Token: 0x06038976 RID: 231798 RVA: 0x00E55F58 File Offset: 0x00E54158
		[NullableContext(2)]
		public MusicalInstrumentSubModel GetSubModel(EInstrumentType type)
		{
			return this.SubModels.GetValueOrDefault(type);
		}

		// Token: 0x06038977 RID: 231799 RVA: 0x00E55F68 File Offset: 0x00E54168
		public MusicalInstrumentQteData ParseQteData(MusicalInstrumentQteConfig config)
		{
			List<MusicalInstrumentQteItemData> list = new List<MusicalInstrumentQteItemData>();
			foreach (List<int> list2 in Json.Parse<List<List<int>>>(config.QteSequence, null))
			{
				list.Add(new MusicalInstrumentQteItemData
				{
					RowIndex = list2[0],
					ColumnIndex = list2[1],
					Finished = false,
					IsFocus = false
				});
			}
			list[0].IsFocus = true;
			return new MusicalInstrumentQteData
			{
				InstrumentType = (EInstrumentType)config.InstrumentType,
				QteId = config.Id,
				ItemDataList = list,
				AudioEvent = Singleton<AudioSystem>.Instance.parseAudioEventPath(config.PreludeAsset)
			};
		}

		// Token: 0x06038978 RID: 231800 RVA: 0x00E56040 File Offset: 0x00E54240
		protected override bool OnClear()
		{
			foreach (MusicalInstrumentSubModel musicalInstrumentSubModel in this.SubModels.Values)
			{
				musicalInstrumentSubModel.OnClear();
				musicalInstrumentSubModel.IsInputRestricted = false;
			}
			this.SubModels.Clear();
			return true;
		}

		// Token: 0x04020494 RID: 132244
		private readonly Dictionary<EInstrumentType, MusicalInstrumentSubModel> SubModels = new Dictionary<EInstrumentType, MusicalInstrumentSubModel>();
	}
}
