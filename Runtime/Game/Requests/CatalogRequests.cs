﻿using LootLocker.LootLockerEnums;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LootLocker.LootLockerEnums
{
    /*
     * Possible entity kinds that catalog entries can have
     */
    public enum LootLockerCatalogEntryEntityKind
    {
        asset = 0,
        currency = 1,
        progression_points = 2,
        progression_reset = 3,
    };
}

namespace LootLocker.Requests
{
    //==================================================
    // Data Definitions
    //==================================================

    /*
     *
     */
    public class LootLockerCatalog
    {
        /*
         * The time when this catalog was created
         */
        public string created_at { get; set; }
        /*
         * The name of the catalog
         */
        public string name { get; set; }
        /*
         * The unique identifying key of the catalog
         */
        public string key { get; set; }
        /*
         * The id of the catalog
         */
        public string id { get; set; }
        /*
         * The time when this catalog was deleted, should normally be null
         */
        public string deleted_at { get; set; }
    }

    /*
     *
     */
    public class LootLockerCatalogPagination
    {
        /*
         * The total available items in this catalog
         */
        public int total { get; set; }
        /*
         * The cursor that points to the next item in the catalog list. Use this in subsequent requests to get additional items from the catalog.
         */
        public string cursor { get; set; }
        /*
         * The cursor that points to the first item in this batch of items.
         */
        public string previous_cursor { get; set; }
    }

    /*
     *
     */
    public class LootLockerCatalogEntryPrice
    {
        /*
         * The amount (cost) set for this price
         */
        public int amount { get; set; }
        /*
         * A prettyfied version of the amount to use for display
         */
        public string display_amount { get; set; }
        /*
         * The short code for the currency this price is in
         */
        public string currency_code { get; set; }
        /*
         * The name of the currency this price is in
         */
        public string currency_name { get; set; }
        /*
         * The unique id of this price
         */
        public string price_id { get; set; }
        /*
         * The unique id of the currency this price is in
         */
        public string currency_id { get; set; }
    }

    /*
     *
     */
    public class LootLockerCatalogEntry
    {
        /*
         * The time when this catalog entry was created
         */
        public string created_at { get; set; }
        /*
         * The kind of entity that this entry is. This signifies in which lookup structure to find the details of this entry by using the grouping_key.
         */
        public LootLockerCatalogEntryEntityKind entity_kind { get; set; }
        /*
         * The name of this entity
         */
        public string entity_name { get; set; }
        /*
         * A list of prices for this catalog entry
         */
        public LootLockerCatalogEntryPrice[] prices { get; set; }
        /*
         * The unique id of the entity that this entry refers to.
         */
        public string entity_id { get; set; }
        /*
         * A unique id for this entry in this catalog grouping the entity and the prices. This is the key you use to look up details about the entity in the structure signified by the entity_kind.
         */
        public string grouping_key { get; set; }
        /*
         * Whether this entry is currently purchasable
         */
        public bool purchasable { get; set; }
    }

    /*
     *
     */
    public class LootLockerAssetDetails
    {
        /*
         * The name of this asset
         */
        public string name { get; set; }
        /*
         * The id of the specific variation of this asset that this refers to
         */
        public string variation_id { get; set; }
        /*
         * The id of the specific rental option of this asset that this refers to
         */
        public string rental_option_id { get; set; }
        /*
         * The legacy id of this asset
         */
        public int legacy_id { get; set; }
        /*
         * The unique identyfing id of this asset.
         */
        public string id { get; set; }
        /*
         * The thumbnail for this asset
         */
        public string thumbnail { get; set; }
        /*
         * The grouping key for this asset detail
         */
        public string grouping_key { get; set; }

    }

    /*
     *
     */
    public class LootLockerProgressionPointDetails
    {
        /*
         * The unique key of the pogression that this refers to
         */
        public string key { get; set; }
        /*
         * The name of the progression that this refers to
         */
        public string name { get; set; }
        /*
         * The amount of points to be added to the progression in question
         */
        public int amount { get; set; }
        /*
         * The unique id of the progression that this refers to
         */
        public string id { get; set; }
        /*
         * The grouping key for this progression point detail
         */
        public string grouping_key { get; set; }
    }

    /*
     *
     */
    public class LootLockerProgressionResetDetails
    {
        /*
         * The unique key of the progression that this refers to
         */
        public string key { get; set; }
        /*
         * The name of the progression that this refers to
         */
        public string name { get; set; }
        /*
         * The unique id of the progression that this refers to
         */
        public string id { get; set; }
        /*
         * The grouping key for this progression reset detail
         */
        public string grouping_key { get; set; }
    }

    /*
     *
     */
    public class LootLockerCurrencyDetails
    {
        /*
         * The name of the currency that this refers to
         */
        public string name { get; set; }
        /*
         * The unique code of the currency that this refers to
         */
        public string code { get; set; }
        /*
         * The amount of this currency to be awarded
         */
        public string amount { get; set; }
        /*
         * The unique id of the currency that this refers to
         */
        public string id { get; set; }
        /*
         * The grouping key for this currency detail
         */
        public string grouping_key { get; set; }
    }

    //==================================================
    // Response Definitions
    //==================================================

    /*
     * 
     */
    public class LootLockerListCatalogsResponse : LootLockerResponse 
    {
        /*
         * A list of the prices for the game
         */
        public LootLockerCatalog[] catalogs { get; set; }
    }

    /*
     *
     */
    public class LootLockerListCatalogPricesResponse : LootLockerResponse
    {
        /*
         * Details about the catalog that the prices is in
         */
        public LootLockerCatalog catalog { get; set; }

        /*
         * A list of entries available in this catalog
         */
        public LootLockerCatalogEntry[] entries { get; set; }
        /*
         * Lookup map for details about entities of entity type assets
         */
        public Dictionary<string /*grouping_key*/, LootLockerAssetDetails> asset_details { get; set; }
        /*
         * Lookup map for details about entities of entity type progression_points
         */
        public Dictionary<string /*grouping_key*/, LootLockerProgressionPointDetails> progression_points_details { get; set; }
        /*
         * Lookup map for details about entities of entity type progression_reset
         */
        public Dictionary<string /*grouping_key*/, LootLockerProgressionResetDetails> progression_resets_details { get; set; }
        /*
         * Lookup map for details about entities of entity type currency
         */
        public Dictionary<string /*grouping_key*/, LootLockerCurrencyDetails> currency_details { get; set; }
        /*
         * Pagination data to use for subsequent requests
         */
        public LootLockerCatalogPagination pagination { get; set; }

        public void AppendCatalogItems(LootLockerListCatalogPricesResponse catalogPrices)
        {
            var concatenatedArray = new LootLockerCatalogEntry[entries.Length + catalogPrices.entries.Length];
            entries.CopyTo(concatenatedArray, 0);
            catalogPrices.entries.CopyTo(concatenatedArray, entries.Length);
            pagination.total = catalogPrices.pagination.total;
            pagination.cursor = catalogPrices.pagination.cursor;

            foreach (var assetDetail in catalogPrices.asset_details)
            {
                asset_details.Add(assetDetail.Key, assetDetail.Value);                
            }
            foreach (var progressionPointDetail in catalogPrices.progression_points_details)
            {
                progression_points_details.Add(progressionPointDetail.Key, progressionPointDetail.Value);
            }
            foreach (var progressionResetDetail in catalogPrices.progression_resets_details)
            {
                progression_resets_details.Add(progressionResetDetail.Key, progressionResetDetail.Value);
            }
            foreach (var currencyDetail in catalogPrices.currency_details)
            {
                currency_details.Add(currencyDetail.Key, currencyDetail.Value);
            }
        }

        public LootLockerListCatalogPricesResponse()
        {
        }

        // This is the way that the response actually looks, but we don't want to expose it, hence the conversion
        private class LootLockerListCatalogItemsWithArraysResponse : LootLockerResponse
        {
            public LootLockerCatalog catalog { get; set; }
            public LootLockerCatalogEntry[] entries { get; set; }
            public LootLockerAssetDetails[] asset_details { get; set; }
            public LootLockerProgressionPointDetails[] progression_points_details { get; set; }
            public LootLockerProgressionResetDetails[] progression_resets_details { get; set; }
            public LootLockerCurrencyDetails[] currency_details { get; set; }
            public LootLockerCatalogPagination pagination { get; set; }
        }

        public LootLockerListCatalogPricesResponse(LootLockerResponse serverResponse)
        {
            LootLockerListCatalogItemsWithArraysResponse parsedResponse = Deserialize<LootLockerListCatalogItemsWithArraysResponse>(serverResponse);
            catalog = parsedResponse.catalog;
            entries = parsedResponse.entries;

            if (parsedResponse.asset_details != null && parsedResponse.asset_details.Length > 0)
            {
                asset_details = new Dictionary<string, LootLockerAssetDetails>();
                foreach (var assetDetail in parsedResponse.asset_details)
                {
                    asset_details.Add(assetDetail.id, assetDetail);
                }
            }

            if (parsedResponse.progression_points_details != null && parsedResponse.progression_points_details.Length > 0)
            {
                progression_points_details = new Dictionary<string, LootLockerProgressionPointDetails>();
                foreach (var detail in parsedResponse.progression_points_details)
                {
                    progression_points_details.Add(detail.id, detail);
                }
            }

            if (parsedResponse.progression_resets_details != null && parsedResponse.progression_resets_details.Length > 0)
            {
                progression_resets_details = new Dictionary<string, LootLockerProgressionResetDetails>();
                foreach (var detail in parsedResponse.progression_resets_details)
                {
                    progression_resets_details.Add(detail.id, detail);
                }
            }

            if (parsedResponse.currency_details != null && parsedResponse.currency_details.Length > 0)
            {
                currency_details = new Dictionary<string, LootLockerCurrencyDetails>();
                foreach (var detail in parsedResponse.currency_details)
                {
                    currency_details.Add(detail.id, detail);
                }
            }
        }

#if UNITY_2020_2_OR_NEWER
        /*
         *
         */
        public class LootLockerInlinedCatalogEntry : LootLockerCatalogEntry
        {
            /*
             * Asset details inlined for this catalog entry, will be null if the entity_kind is not asset
             */
            public LootLockerAssetDetails? asset_details { get; set; }
            /*
             * Progression point details inlined for this catalog entry, will be null if the entity_kind is not progression_points
             */
            public LootLockerProgressionPointDetails? progression_point_details { get; set; }
            /*
             * Progression reset details inlined for this catalog entry, will be null if the entity_kind is not progression_reset
             */
            public LootLockerProgressionResetDetails? progression_reset_details { get; set; }
            /*
             * Currency details inlined for this catalog entry, will be null if the entity_kind is not currency
             */
            public LootLockerCurrencyDetails? currency_details { get; set; }

            public LootLockerInlinedCatalogEntry(LootLockerCatalogEntry entry, [CanBeNull] LootLockerAssetDetails assetDetails, [CanBeNull] LootLockerProgressionPointDetails progressionPointDetails, [CanBeNull] LootLockerProgressionResetDetails progressionResetDetails, [CanBeNull] LootLockerCurrencyDetails currencyDetails) 
            {
                created_at = entry.created_at;
                entity_kind = entry.entity_kind;
                entity_name = entry.entity_name;
                entity_id = entry.entity_id;
                prices = entry.prices;
                grouping_key = entry.grouping_key;
                purchasable = entry.purchasable;
                asset_details = assetDetails;
                progression_point_details = progressionPointDetails;
                progression_reset_details = progressionResetDetails;
                currency_details = currencyDetails;
            }
        }

        /*
         * Get all the entries with details inlined into the entries themselves
         */
        public LootLockerInlinedCatalogEntry[] GetLootLockerInlinedCatalogEntries()
        {
            List<LootLockerInlinedCatalogEntry> inlinedEntries = new List<LootLockerInlinedCatalogEntry>();
            foreach (var lootLockerCatalogEntry in entries)
            {
                var groupingKey = lootLockerCatalogEntry.grouping_key;
                var entityKind = lootLockerCatalogEntry.entity_kind;
                inlinedEntries.Add(new LootLockerInlinedCatalogEntry(
                    lootLockerCatalogEntry, 
                    LootLockerCatalogEntryEntityKind.asset == entityKind && asset_details.ContainsKey(groupingKey) ? asset_details[groupingKey] : null, 
                    LootLockerCatalogEntryEntityKind.progression_points == entityKind && progression_points_details.ContainsKey(groupingKey) ? progression_points_details[groupingKey] : null, 
                    LootLockerCatalogEntryEntityKind.progression_reset == entityKind && progression_resets_details.ContainsKey(groupingKey) ? progression_resets_details[groupingKey] : null, 
                    LootLockerCatalogEntryEntityKind.currency == entityKind && currency_details.ContainsKey(groupingKey) ? currency_details[groupingKey] : null
                ));
            }
            return inlinedEntries.ToArray();
        }
#endif
    }
}
