﻿using HutongGames.PlayMaker;
using UnityEngine;

namespace Devdog.Rucksack.Integrations.PlayMaker
{
    [ActionCategory(RucksackConstants.ProductName + "/Collections/Boxed")]
    public class GetAmountByIndexBoxed : BoxedCollectionAction
    {
        public FsmInt index;
        public FsmInt amountResult;
        
        public override string ErrorCheck()
        {
            var result = base.ErrorCheck();
            if (amountResult.IsNone || amountResult.UseVariable == false)
            {
                result += nameof(amountResult) + " variable not set" + "\n";
            }

            return result;
        }

        public override void OnEnter()
        {
            var col = ((BoxedCollectionWrapper)collection.Value).collection;
            amountResult.Value = col.GetAmount(index.Value);
            Finish();
        }
    }
}