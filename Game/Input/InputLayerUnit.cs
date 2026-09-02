using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FD2 RID: 28626
	[NullableContext(1)]
	[Nullable(0)]
	public class InputLayerUnit
	{
		// Token: 0x0604542F RID: 283695 RVA: 0x01217A80 File Offset: 0x01215C80
		public void Add(InputLayer layer)
		{
			EInputLayer layerType = layer.GetLayerType();
			InputLayer inputLayer;
			if (this.LayerMap.TryGetValue(layerType, out inputLayer))
			{
				inputLayer.Clear();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.WWJ;
				string message = "[InputLayerUnit]添加的InputLayer类型已存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LayerType", layerType);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.LayerMap[layerType] = layer;
			this.Sort();
		}

		// Token: 0x06045430 RID: 283696 RVA: 0x01217AEC File Offset: 0x01215CEC
		public void Remove(InputLayer layer)
		{
			EInputLayer layerType = layer.GetLayerType();
			if (this.LayerMap.ContainsKey(layerType))
			{
				this.LayerMap.Remove(layerType);
				this.Sort();
			}
		}

		// Token: 0x06045431 RID: 283697 RVA: 0x01217B24 File Offset: 0x01215D24
		public void Sort()
		{
			this.LayerList = new List<InputLayer>(this.LayerMap.Values);
			this.LayerList.Sort((InputLayer a, InputLayer b) => b.GetLayerType() - a.GetLayerType());
		}

		// Token: 0x06045432 RID: 283698 RVA: 0x01217B74 File Offset: 0x01215D74
		public void Clear()
		{
			foreach (InputLayer inputLayer in this.LayerMap.Values)
			{
				inputLayer.Clear();
			}
			this.LayerMap.Clear();
		}

		// Token: 0x06045433 RID: 283699 RVA: 0x01217BD4 File Offset: 0x01215DD4
		public List<InputLayer> GetLayerList()
		{
			return this.LayerList;
		}

		// Token: 0x04026A70 RID: 158320
		public readonly Dictionary<EInputLayer, InputLayer> LayerMap = new Dictionary<EInputLayer, InputLayer>();

		// Token: 0x04026A71 RID: 158321
		private List<InputLayer> LayerList = new List<InputLayer>();
	}
}
